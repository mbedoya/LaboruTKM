using LaboruTKM.Data;
using LaboruTKM.Common;
using LaboruTKM.Common.AssesmentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LaboruTKM.Utilities;
using LaboruTKM.Common.AssesmentAnalysis;

namespace LaboruTKM.Model
{
    public class Assesment
    {
        EvaluationDB db = new EvaluationDB();

        private int id;
        private string assesmentID;
        private int currentQuestionAnswerIndex;
        private bool responseWasRight;
        private List<QuestionResponseTO> currentSectionResponses;
        private AssesmentContextTO currentContext;
        private AssesmentTO info;

        public Assesment(int id)
        {
            this.id = id;

            info =
                (from a in db.Assesments
                 where a.AssesmentId == id
                 select a).FirstOrDefault();

            if (info != null)
            {
                info =
                (from a in db.Assesments.Include("Company").Include("Evaluation").AsNoTracking()
                 where a.AssesmentId == id
                 select a).FirstOrDefault();

                InitAdditionalData();
            }
        }

        public Assesment(string assesmentID)
        {
            info =
                (from a in db.Assesments
                 where a.AssesmentKey == assesmentID
                 select a).FirstOrDefault();

            if (info != null)
            {
                info =
                (from a in db.Assesments.Include("Company").Include("Evaluation").AsNoTracking()
                 where a.AssesmentKey == assesmentID
                 select a).FirstOrDefault();

                this.assesmentID = assesmentID;
                this.id = info.AssesmentId;
                InitAdditionalData();
            }
        }

        private void InitAdditionalData()
        {
            GetSections();
            CreateContext();
        }

        public AssesmentContextTO GetCurrentContext()
        {
            return currentContext;
        }

        public AssesmentTO GetInfo()
        {
            return info;
        }

        private void GetSections()
        {
            if (info != null && info.Evaluation != null)
            {
                info.Evaluation.Sections = new Evaluation(info.Evaluation.Id).GetSections();
            }
        }

        public void Restart()
        {
            AssesmentTO assesment = db.Assesments.Find(id);
            assesment.DateFinished = null;
            assesment.DateStarted = null;
            db.Entry(assesment).CurrentValues.SetValues(assesment);
            db.SaveChanges();

            UpdateBdContext(id, GetDefaultContext());
        }

        public AssesmentAnswerQuestionResult AnswerQuestion(int responseIndex)
        {
            if (responseIndex <= 0)
            {
                return AssesmentAnswerQuestionResult.InvalidResponse;
            }

            if (responseIndex > GetCurrentQuestion().Answers.Count)
            {
                return AssesmentAnswerQuestionResult.InvalidResponse;
            }

            UpdateResponseStatus(responseIndex);
            SaveResponse();
            CheckAndEndAssesment();
            UpdateContext();

            return AssesmentAnswerQuestionResult.Successful;
        }

        private QuestionTO GetCurrentQuestion()
        {
            return currentContext.CurrentSectionQuestions[currentContext.QuestionIndex - 1];
        }

        private void UpdateResponseStatus(int responseIndex)
        {
            responseWasRight = responseIndex == currentQuestionAnswerIndex;
        }

        private void CheckAndEndAssesment()
        {
            if (info.Evaluation.Sections.Count == currentContext.SectionIndex &&
                currentContext.CurrentSectionQuestions.Count == currentContext.QuestionIndex)
            {
                End();
            }
        }

        private void UpdateContext()
        {
            if (SectionHasNextQuestion())
            {
                currentContext.QuestionIndex++;

                UpdateQuestionResponseInfo();
            }
            else
            {
                if (EvaluationHasNextSection())
                {
                    MoveToNextSection();
                }
            }
            UpdateBdContext(id, currentContext);
        }

        private void UpdateBdContext(int id, AssesmentContextTO contextToSave)
        {
            AssesmentContextTO context =
                (from c in db.AssesmentsContexts
                 where c.AssesmentId == id
                 select c).FirstOrDefault();

            if (context != null)
            {
                context.SectionIndex = contextToSave.SectionIndex;
                context.MinutesLeft = contextToSave.MinutesLeft;
                context.QuestionIndex = contextToSave.QuestionIndex;

                db.Entry(context).CurrentValues.SetValues(context);
                db.SaveChanges();
            }
        }

        private void MoveToNextSection()
        {
            currentContext.SectionIndex++;
            currentContext.QuestionIndex = 1;
            currentContext.MinutesLeft = ConvertEstimatedDurationToMinutesLeft(info.Evaluation.Sections.ElementAt(currentContext.SectionIndex - 1).EstimatedDuration);

            UpdateSectionResponseInfo();
        }

        private void SaveResponse()
        {
            QuestionTO question = GetCurrentQuestion();

            AssesmentResponseTO response = new AssesmentResponseTO();
            response.AnswerIsRight = responseWasRight;
            response.AssesmentID = id;
            response.QuestionId = question.QuestionId;
            response.AnswerId = question.Answers.ElementAt(currentQuestionAnswerIndex - 1).AnswerId;
            db.AssesmentResponses.Add(response);

            db.SaveChanges();
        }

        public bool ResponseWasRight()
        {
            return responseWasRight;
        }

        private bool SectionHasNextQuestion()
        {
            return currentContext.CurrentSectionQuestions.Count > currentContext.QuestionIndex;
        }

        public bool EvaluationHasNextSection()
        {
            return info.Evaluation.Sections.Count > currentContext.SectionIndex;
        }

        public void UpdateLeftTime()
        {
            if (info.Status != AssesmentStatus.Started)
            {
                return;
            }

            currentContext.MinutesLeft = currentContext.MinutesLeft - 1;
            if (currentContext.MinutesLeft < 0)
            {
                currentContext.MinutesLeft = 0;
            }

            if (currentContext.MinutesLeft == 0)
            {
                if (EvaluationHasNextSection())
                {
                    MoveToNextSection();
                }
                else
                {
                    End();
                }
            }

            UpdateBdContext(id, currentContext);
        }

        public AssesmentStartOperationState Start()
        {
            if (info == null)
            {
                return AssesmentStartOperationState.AssementNotFound;
            }

            if (info.DateStarted != null)
            {
                return AssesmentStartOperationState.AlreadyStarted;
            }

            info.DateStarted = DateTime.Now;
            info.Status = AssesmentStatus.Started;
            SetDbStartDate(id);
            CreateContext();

            return AssesmentStartOperationState.Successful;
        }

        private void SetDbStartDate(int id)
        {
            AssesmentTO assesment = db.Assesments.Find(id);
            assesment.DateStarted = DateTime.Now;
            db.Entry(assesment).CurrentValues.SetValues(assesment);
            db.SaveChanges();
        }

        private void SetDbFinishDate(int id)
        {
            AssesmentTO assesment = db.Assesments.Find(id);
            assesment.DateFinished = DateTime.Now;
            db.Entry(assesment).CurrentValues.SetValues(assesment);
            db.SaveChanges();
        }

        private void CreateContext()
        {
            if (info != null)
            {
                if (info.Status == AssesmentStatus.Created)
                {
                    currentContext = GetDefaultContext();
                    currentContext.MinutesLeft = ConvertEstimatedDurationToMinutesLeft(info.Evaluation.Sections.ElementAt(0).EstimatedDuration);

                    CreateDbContext(id, currentContext);
                }
                else
                {
                    currentContext = GetDbContext(id);
                }

                UpdateSectionResponseInfo();
            }
        }

        private void CreateDbContext(int id, AssesmentContextTO context)
        {
            context.AssesmentId = id;
            db.AssesmentsContexts.Add(context);
            db.SaveChanges();
        }

        private AssesmentContextTO GetDbContext(int id)
        {
            AssesmentContextTO context =
                (from c in db.AssesmentsContexts
                 where c.AssesmentId == id
                 select c).FirstOrDefault();

            return context;
        }

        public AssesmentEndOperationState End()
        {
            if (info.Status == AssesmentStatus.Created)
            {
                return AssesmentEndOperationState.AssementNotStarted;
            }

            if (info.Status == AssesmentStatus.Done)
            {
                return AssesmentEndOperationState.AlreadyDone;
            }

            info.Status = AssesmentStatus.Done;
            info.DateFinished = DateTime.Now;
            SetDbFinishDate(id);
            GenerateAndSendResults();

            return AssesmentEndOperationState.Successful;
        }

        private List<SectionPointsTO> GetDbAssesmentPoints(int id)
        {
            /*
            SELECT s.ID, SUM(Points) as Points " +
                " FROM question q " +
                " JOIN assesment_response ar on q.id = ar.questionid " +
                " JOIN section s on  s.id=q.SectionID " +
                " WHERE ar.assesmentid = {0} and ar.answerisright = 1 " +
                " GROUP by s.ID */

            List<SectionPointsTO> list =
                (from q in db.Questions
                join ar in db.AssesmentResponses on q.QuestionId equals ar.QuestionId
                 join s in db.Sections on q.QuestionId equals s.SectionId
                where ar.AssesmentID == id && ar.AnswerIsRight
                group q by q.SectionId into g
                select new SectionPointsTO { SectionID = g.Key, Points = g.Sum(x => x.Points) }).ToList();

            return list;
        }

        private void GenerateAndSendResults()
        {
            AssesmentReportTO report = new AssesmentReportTO();
            report.AssesmentInfo = info;
            report.Sections = new List<SectionReportTO>();

            List<SectionPointsTO> list = GetDbAssesmentPoints(id);
            for (int i = 0; i < info.Evaluation.Sections.Count; i++)
            {
                SectionReportTO section = new SectionReportTO();
                section.Name = info.Evaluation.Sections.ElementAt(i).Name;
                section.Percentage = 0;
                SectionPointsTO sectionPoints = list.Find(x => x.SectionID == info.Evaluation.Sections.ElementAt(i).SectionId);
                if (sectionPoints != null)
                {
                    section.Percentage = sectionPoints.Points;
                }

                report.Sections.Add(section);
            }

            report.Analysis = GetAnalysis();
            string savedFilePath = Pdf.GenerateSimplePdf(report);
            SendReport(savedFilePath);
        }

        private AssesmentAnalysisReportTO GetAnalysis()
        {
            AssesmentAnalysisReportTO analysis = AssesmentAnalysisModel.GetAssesmentAnalysis(id);

            //Set Senority based on points
            if (analysis.RoleLevels != null && analysis.RoleLevels.Count > 0)
            {
                string roleTitle = analysis.RoleLevels[0].Name;
                foreach (var item in analysis.RoleLevels)
                {
                    if (item.Points <= analysis.RoleResult.Points)
                    {
                        roleTitle = item.Name;
                    }
                }
                analysis.RoleResult.Title = analysis.RoleResult.Title + " " + roleTitle;
            }

            if (info.Type == AssementType.Candidate)
            {
                analysis.Candidates = AssesmentAnalysisModel.GetAssesmentCandidates(id).OrderByDescending(x => x.Points).ToList();
            }

            return analysis;
        }

        private void SendReport(string filePath)
        {
            MailMessageTO message = new MailMessageTO();
            message.Title = "Resultado Evaluación " + info.Employee.Name;
            message.ToEmail = new Company().Get(info.Company.CompanyId).ContactEmail;
            message.ToName = info.Employee.Name;

            string body = String.Format("<p>Buenos días,</p><p>Estamos enviando el resultado de la evaluación <b>{0}</b> de {1}</p><p>Saludos cordiales,</p>",
                info.Evaluation.Name, info.Employee.Name);
            message.Body = body;
            message.Attachements = new List<string>();
            message.Attachements.Add(filePath);

            Mail mail = new Mail(message);
            mail.Send();
        }

        private void UpdateSectionResponseInfo()
        {
            SetCurrentSectionQuestions();
            UpdateQuestionResponseInfo();
        }

        private void SetCurrentSectionQuestions()
        {
            Section section = new Section();
            currentContext.CurrentSectionQuestions = section.GetQuestionsBySection(info.Evaluation.Sections.ElementAt(currentContext.SectionIndex - 1));
        }

        private void UpdateQuestionResponseInfo()
        {
            currentSectionResponses = new Section().GetResponsesBySection(info.Evaluation.Sections.ElementAt(currentContext.SectionIndex - 1));
            int currentQuestionAnswerID = currentSectionResponses.Find(x => x.QuestionID == currentContext.CurrentSectionQuestions[currentContext.QuestionIndex - 1].QuestionId).AnswerID;

            currentQuestionAnswerIndex = 0;
            QuestionTO question = GetCurrentQuestion();

            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers.ElementAt(i).AnswerId == currentQuestionAnswerID)
                {
                    currentQuestionAnswerIndex = i + 1;
                    break;
                }
            }
        }

        private AssesmentContextTO GetDefaultContext()
        {
            return new AssesmentContextTO() { QuestionIndex = 1, SectionIndex = 1 };
        }

        private int ConvertEstimatedDurationToMinutesLeft(double estimatedDuration)
        {
            return Convert.ToInt32(estimatedDuration * 60);
        }
    }
}
