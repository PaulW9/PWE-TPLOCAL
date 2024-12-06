using System;
using System.Collections.Generic;
using System.Xml;

namespace TPLOCAL1.Models 
{
    public class Reviews 
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string AvisDonne { get; set; }
    }

    public class Opinion
    {
        public List<Reviews> GetAvis(string file)
        {
            List<Reviews> listReviews = new List<Reviews>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);  

            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))  
            {
                var review = new Reviews
                {
                    Name = node["Name"]?.InnerText,
                    FirstName = node["FirstName"]?.InnerText,
                    AvisDonne = node["Avis"]?.InnerText == "Y" ? "Oui" : "Non"
                };

                listReviews.Add(review);  
            }

            return listReviews;
        }
    }
}
