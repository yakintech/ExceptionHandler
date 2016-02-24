using MVCErrorHandling.Data.Context;
using MVCErrorHandling.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCErrorHandling.Infrastructure
{
    public class ErrorHandlingAttribute : FilterAttribute, IExceptionFilter
    {
        private IErrorLogger<ErrorLog> _logger;
        private IMessageProvider _msg;

        public ErrorHandlingAttribute(Logger logger = null, MessageService msg = null)
        {
            _logger = logger;
            _msg = msg;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = new
                    {
                        name = filterContext.Exception.GetType().Name,
                        message = filterContext.Exception.Message,
                        trace = filterContext.Exception.StackTrace

                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
                //Internal Error

            }
            else
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;

                var ControllerName = (string)filterContext.RouteData.Values["controller"];
                var ActionName = (string)filterContext.RouteData.Values["action"];

                var data = new HandleErrorInfo(filterContext.Exception, ControllerName, ActionName);

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(data)

                };


                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;

            }

            ErrorLog log = new ErrorLog()
            {
                Message = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = (string)filterContext.RouteData.Values["controller"],
                ActionName = (string)filterContext.RouteData.Values["action"],
                TargetedResult = filterContext.Result.GetType().Name,
                TimeStamp = DateTime.Now,
                UserAgent = filterContext.HttpContext.Request.UserAgent,
                IPAdress = filterContext.HttpContext.Request.UserHostAddress,
                SessionID = null,
                ExceptionName = filterContext.Exception.GetType().Name

            };

            #region loggerService


            if (_logger != null)
            {
                _logger.Log(log);

            }
            #endregion

            #region emailService

            if (_msg != null)
            {
                _msg.SendEmail(new EmailDetails
                {
                    From = "alptekin.mert.45@gmail.com",
                    Body = filterContext.Exception.Message + Environment.NewLine + filterContext.Exception.StackTrace,
                    ToAddresses = "alptekin.mert@outlook.com",

                });
            }

            #endregion




        }


    }
}