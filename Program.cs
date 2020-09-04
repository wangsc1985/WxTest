using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTest.helper;
using LitJson;

namespace WxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = HttpHelper.GetHttp("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxbdf065bdeba96196&secret=d2834f10c0d81728e73a4fe4012c0a5d");
            JsonData jsonData = JsonMapper.ToObject(html);
            string access_token = jsonData["access_token"].ToString();
            Console.WriteLine(access_token);


            string path = @"d:\mp.db";
            //string body = $"env=yipinshangdu-4wk7z&path={path}";
            string body = "{\"env\":\"yipinshangdu-4wk7z\",\"path\":\""+ path + "\"}";
            string url = $"https://api.weixin.qq.com/tcb/uploadfile?access_token={access_token}";
            html = HttpHelper.PostHttpByJson(url, body);

            var info = JsonHelper.getInfo(html);
            Console.WriteLine(info.authorization);
            Console.WriteLine(info.cos_file_id);
            Console.WriteLine(info.errcode);
            Console.WriteLine(info.errmsg);
            Console.WriteLine(info.file_id);
            Console.WriteLine(info.token);
            Console.WriteLine(info.url);

            body = "{\"key\":\"" + path + "\",\"Signature\":\""+info.authorization+ "\",\"x - cos - security - token\":\"" + info.token + "\",\"x - cos - meta - fileid\":\"" 
                + info.cos_file_id + "\",\"file\":\"" + path + "\"}";
            HttpHelper.PostHttpByData(info.url,body);


            // key d:\mp.db 请求包中的 path 字段
            // Signature   q - sign - algorithm = sha1 & q - ak = AKID9...	返回数据的 authorization 字段
            // x - cos - security - token    Cukha70zkXIBqkh1Oh...	返回数据的 token 字段
            // x - cos - meta - fileid   HDze32 / qZENCwWi5...	返回数据的 cos_file_id 字段
            // file    文件内容 文件的二进制内容




            //string funName = "getUserLoginTime";
            //string body = "{\"_openid\":\"oBJCI5B_YBpo3raJSD4MEMSaC37w\"}";
            //string url = $"https://api.weixin.qq.com/tcb/invokecloudfunction?access_token={access_token}&env=yipinshangdu-4wk7z&name={funName}";
            //Console.WriteLine(url);
            ////html = HttpHelper.GetHttp(url);
            //html = HttpHelper.PostHttpByJson(url, body);

            //Console.WriteLine(html);


            Console.ReadKey();
        }
    }
}
