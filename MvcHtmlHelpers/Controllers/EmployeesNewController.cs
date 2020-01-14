using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;
using System.Data.Entity;
using System.Net;


namespace MvcHtmlHelpers.Controllers
{
    public class EmployeesNewController : Controller
    {
        // 初始化 Enitity Framwork 的 Context 的環境,用來對資料庫的存取
        private CmsContext db = new CmsContext();

        // GET: Employees
        public ActionResult Index()
        {
            var emps = db.EmployeesNews.ToList();
            return View(emps);
        }

        // GET
        public ActionResult Details(int? Id)
        {
            // 是否傳入 Id
            if (Id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            EmployeesNew emps = db.EmployeesNews.Find(Id);
            // 找不到 User
            if (emps == null) { return HttpNotFound(); }
            return View(emps);
        }

        // 新增需要用到 POST/GET

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // 防止跨網站偽造請求的攻擊與法
        [ValidateAntiForgeryToken]  
        // 傳入 (emps)
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] EmployeesNew emps)
        {
            // 用ModelState.IsValid 判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                // 驗證過 DB 寫入
                db.EmployeesNews.Add(emps);
                // 確認寫入
                db.SaveChanges();
                // 轉到首頁
                return RedirectToAction("Index");
            }
            // 未通過驗證,返回顯示 Form 表單,直到資料完全驗證正確
            return View(emps);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null) { return Content("查無員工資料, 請提供員工編號"); }            
            // 以Id 尋找員工資料
            EmployeesNew emp = db.EmployeesNews.Find(Id);
            // 如果沒有找到員工,回傳 HttpNotFound
            if(emp == null) { return HttpNotFound(); }

            return View(emp);
        }

        [HttpPost]
        // 傳入 (emps)
        // Bind 是用來指定欲異動的欄位, 以防止 Over-Posting 攻擊
        public ActionResult Edit([Bind(Include = "Id, Name, Mobile, Email, Department, Title")] EmployeesNew emps)
        {            
            // 使用 ModelState.IsValid 判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                // 將 emps 這個 Enitity狀態設為 Modified
                db.Entry(emps).State = EntityState.Modified;
                // 當SaveChange() 執行時, 會向 SQL Server 發出 Update 指令
                db.SaveChanges();
                // 返回首頁
                return RedirectToAction("Index");
            }

            return View(emps);
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if(Id == null) { return Content("查無員工資料, 請提供員工編號"); }
            // 以Id 尋找員工資料
            EmployeesNew emp = db.EmployeesNews.Find(Id);
            // 如果沒有找到員工, 回傳 HttpNotFound
            if(emp == null) { return HttpNotFound(); }

            return View(emp);
        }

        [HttpPost]
        // 防止跨網站偽造請求的攻擊與法
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            // 以Id 尋找員工資料
            EmployeesNew emp = db.EmployeesNews.Find(Id);
            db.EmployeesNews.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}