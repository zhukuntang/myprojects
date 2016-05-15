using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Collections;

namespace zhsqw.Controllers.webapi
{
    [Route("api/uploadfile")]
    public class uploadfile : Controller
    {
        [HttpPost]
        public string Post()
        {
            //上传配置
            int size = 5;                                                           //文件大小限制,单位MB
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };        //文件允许格式

            //上传图片
            Hashtable info = new Hashtable();
            Uploader up = new Uploader();

            string pathbase = "/uploads/";
            int path = Convert.ToInt32(up.getOtherInfo(HttpContext, "dir"));

            info = up.upFile(HttpContext, pathbase, filetype, size);                //获取上传状态

            string title = up.getOtherInfo(HttpContext, "pictitle");                //获取图片描述

            string json = "{'url':'" + info["url"] + "','title':'" + title + "','fileType':'" + info["currentType"] + "','original':'" + info["originalName"] + "','state':'" + info["state"] + "'}";  //向浏览器返回数据json数据

            return json;
        }
    }
}
