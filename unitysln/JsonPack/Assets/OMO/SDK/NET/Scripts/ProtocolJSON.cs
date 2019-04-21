using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace OMO.SDK.NET
{
    public class ProtocolJSON
    {
        public class RequestHead
        {
            public string msg = "";
            public string session = "";
        }

        public class ResponseHead
        {
            public string msg = "";
            public string session = "";
            public int errcode = 0;
            public string errstring = "";
        }

        public class NotifyHead
        {
            public string msg = "";
        }

        public class Request
        {
            public RequestHead head = new RequestHead();
			public JSONClass body = new JSONClass();
        }

        public class Response
        {
            public ResponseHead head = new ResponseHead();
			public JSONClass body = new JSONClass();
        }

        public class Notify
        {
            public NotifyHead head = new NotifyHead();
			public JSONClass body = new JSONClass();
        }

        public static string RequestToJSON(Request _req)
        {
			JSONClass head = new JSONClass();
			head.Add("msg", new JSONData(_req.head.msg));
			head.Add("session", new JSONData(_req.head.session));

            JSONClass root = new JSONClass();
			root.Add("head", head);
			root.Add("body", _req.body);
			return root.ToJSON(0);
    	}

		public static string ResponseToJSON(Response _rsp)
        {
			JSONClass head = new JSONClass();
			head.Add("msg", new JSONData(_rsp.head.msg));
			head.Add("session", new JSONData(_rsp.head.session));

            JSONClass root = new JSONClass();
			root.Add("head", head);
			root.Add("body", _rsp.body);
			return root.ToJSON(0);
    	}

		public static string NotifyToJSON(Notify _notify)
        {
			JSONClass head = new JSONClass();
			head.Add("msg", new JSONData(_notify.head.msg));

            JSONClass root = new JSONClass();
			root.Add("head", head);
			root.Add("body", _notify.body);
			return root.ToJSON(0);
    	}

		public static Request RequestFromJSON(string _json)
        {
			JSONClass root = JSON.Parse(_json).AsObject;
			JSONClass head = root["head"].AsObject;
			JSONClass body = root["body"].AsObject;

			Request req = new Request();
			req.head.msg = head["msg"].Value;
			req.head.session = head["session"].Value;
			req.body = body;
			return req;
    	}

		public static Response ResponseFromJSON(string _json)
        {
			JSONClass root = JSON.Parse(_json).AsObject;
			JSONClass head = root["head"].AsObject;
			JSONClass body = root["body"].AsObject;

			Response rsp = new Response();
			rsp.head.msg = head["msg"].Value;
			rsp.head.session = head["session"].Value;
			rsp.body = body;
			return rsp;
    	}

		public static Notify NotifyFromJSON(string _json)
        {
			JSONClass root = JSON.Parse(_json).AsObject;
			JSONClass head = root["head"].AsObject;
			JSONClass body = root["body"].AsObject;

			Notify nty = new Notify();
			nty.head.msg = head["msg"].Value;
			nty.body = body;
			return nty;
    	}

    }//class
}//namespace