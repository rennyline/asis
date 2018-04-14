using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DSupportWebApp.Models;

namespace DSupportWebApp.Controllers
{

    public class AsisBaseController : Controller
    {
           private static dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: AsisBase
        public ActionResult Intialize(ActionResult result, string prefix, int IDControllerView)
        {
            TranslateController(prefix, IDControllerView);

            return CheckAuthorisation(result);
        }

        private void TranslateController(string prefix, int IDControllerView)
        {
            //ViewBag.EditText = "Bewerk";
            //ViewBag.DeleteText = "Verwijder";
            //ViewBag.BackToListText = "Terug naar de lijst";
            //object ds = null;
            string strSQL = "";
            strSQL += "SELECT Name{0} ";
            strSQL += "FROM {1}_ControllerViewTranslate";
            strSQL += "WHERE IDControllerView={2} ";
            strSQL += "ORDER BY SortID";
            strSQL = string.Format(strSQL, Session["asisLangCode"] as string, prefix, IDControllerView);
            var ds = AsisModelHelper.GetDataSet(strSQL);

            ViewBag.label = new List<string>();

            //ViewBag.label[0] = ds.jdjdj;
            // convert object tot arraylist
            //int Total = 10;
            //string arlist[Total];

            //// add records in an arraylist
            //ViewBag.Collection = arlist;

        }



        // GET: AsisBase
        public ActionResult CheckAuthorisation(ActionResult result = null)
        {

            if (!IsUserAuthorized()) // NOT in vusual basic is ! i C#
            {
                ViewBag.Name = AsisModelHelper.GetMessage(1, "asis", Session["asisLangCode"] as string);
                //throw new Exception(ViewBag.Name);
                //return null;
                return View("AsisError");
            }
            return result;
        }

        // de constructur is een routine met dezelfde naam als de class en public
        public bool IsUserAuthorized()
        {
            if (Session["IDUserGroup"] == null || Session["IDUser"] == null) // OR in vb is || in C# en AND in VB is && in C#
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        internal void BeforeEdit(object record)
        {
            Session["prevRecord"] = record;
        }

        internal void AfterEdit(object record, int IDAttRecordOperation, int IDUser, string tableName)
        {

            int IDAsisTableList = GetAsisTableID(tableName);
            if (!HasHistory(IDAsisTableList))
            {
                return; //deze tabel heeft geen history, ER UIT!!!!!
            }

            //int IDUser = 1;
            //int IDAttRecordOperation = 1;
            DateTime DateOperation = DateTime.Now;
            string lblPrevious = AsisModelHelper.GetMessage(2, "asis", Convert.ToString(Session["asisLangCode"]));
            string lblCurrent = AsisModelHelper.GetMessage(3, "asis", Convert.ToString(Session["asisLangCode"]));
            string LF = "\n";
            //IDParam,KeyNL,KeyEN,Value,IDUserCreated,IDUserModified,DateCreated,DateModified

            //var lastRecord = Session["lastRecord"] as asis_param;
            //var currentRecord = record as asis_param;
            //bool isModified = (lastRecord.IDParam != currentRecord.IDParam);

            //var propObject = data.Result[0];
            //var propInfo = propObject.GetType().GetProperty(fieldName);
            //var message = propInfo.GetValue(propObject);
            string strHistory = "";

            var index = 0;
            int IDRecord = 0;
            var prevRecord = Session["prevRecord"];
            foreach (PropertyInfo prop in record.GetType().GetProperties())
            {
                PropertyInfo propPrev = prevRecord.GetType().GetProperties()[index];
                var prevFieldName = propPrev.Name;
                var prevFieldValue = Convert.ToString(propPrev.GetValue(prevRecord));

                var fieldName = prop.Name;
                var fieldValue = Convert.ToString(prop.GetValue(record));
                if (index == 0)
                {
                    IDRecord = Convert.ToInt32(fieldValue);
                }

                bool isModified = (fieldValue != prevFieldValue);
                if (isModified)
                {
                    strHistory += string.Format(lblPrevious, prevFieldName, prevFieldValue);
                    strHistory += LF;
                    strHistory += string.Format(lblCurrent, fieldName, fieldValue);
                    strHistory += LF;
                }

                index++;
            }

            if (!SaveHistory(IDAsisTableList, IDRecord, Convert.ToInt32(Session["IDUser"]), IDAttRecordOperation, DateTime.Now, strHistory))
            {
                RedirectToAction("Index","AsisError", new {
                    IDMessage=6,
                    prefix = "asis",
                });
            }
        }

        private int GetAsisTableID(string tableName)
        {
            var IDTableList = db.asis_tablelist.Where(i => i.TableName == tableName).Select(l => l.IDAsisTableList).SingleOrDefault();
            //var IDTableList = 6; 

            return IDTableList;
        }

        private bool HasHistory(int IDAsisTableList)
        {
            var hasHistory = db.asis_tablelist.Where(i => i.IDAsisTableList == IDAsisTableList).Select(l => l.HasHistory).Any();
            return hasHistory;
        }

        private bool SaveHistory(int IDAsisTableList, int RecordID, int IDUser, int IDAttRecordOperation, DateTime dateOperation, string strHistory)
        {
            bool saved = false;
            db.asis_tablelog.Add(new asis_tablelog {
                IDAsisTableList = IDAsisTableList,
                RecordID = RecordID,
                IDUser = IDUser,
                IDAttRecordOperation = IDAttRecordOperation,
                DateOperation = dateOperation,
                Logchange = strHistory 
            });

            saved = db.SaveChanges() > 0;

            return saved;
        }

    }
}