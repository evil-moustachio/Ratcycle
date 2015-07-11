using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Ratcycle
{
    public class UpdateHandler
    {
        private string _url;

        public UpdateHandler()
        {
            _url = "http://evil-moustachio.github.io/Ratcycle/";
        }

        public void CheckUpdate()
        {
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(_url);
                if (!htmlCode.Contains(Model.Settings.Version))
                {
                    System.Diagnostics.Process.Start(_url);
                }
            }
        }
    }
}
