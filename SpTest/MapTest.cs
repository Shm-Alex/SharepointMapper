using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shmapper;

namespace SpTest
{
    [TestClass]
    public class MapTest
    {private static ISpClient  spclient;
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            // _sharepointClient = new SharepointClient("http://sp-dev2016-obl.mont.ru/sites/b2b", new NetworkCredential("SP_Portal", "Mont2010"));

            //spclient = new SpClient(new SharepointClient("http://sp-dev2016-obl.mont.ru/sites/b2b", new NetworkCredential("SP_Portal", "Mont2010")));
            spclient = new SpClient(new SharepointClient("http://sp-test2016.mont.ru/sites/b2b/", new NetworkCredential("SP_Portal", "Mont2010")));
        }

        [TestMethod]
        public void TestAttachment()
        {
            var speaker = spclient.GetById<Speaker>(1);
            //List<SpVendorBlock> spVendorBlocks = _sharepointClient.GetAll<SpVendorBlock>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var eventBlocksList = spclient.GetById<EventBlocksList>(18);
            //List<SpVendorBlock> spVendorBlocks = _sharepointClient.GetAll<SpVendorBlock>();
        }
        [TestMethod]
        public void GetAll_EventBlocksList()
        {
            var eventBlocksList = spclient.GetAll<EventBlocksList>();
            //List<SpVendorBlock> spVendorBlocks = _sharepointClient.GetAll<SpVendorBlock>();
        }

        [TestMethod]
        public void lectuerBlockQuery()
        {
            int id = 4157;

            List<Lecture> lectures = spclient.Query<Lecture>(l => l.ReportBlockId == 1);
            var Event = spclient.GetById<Event>(id);
            var reportBlockLists = spclient.Query<ReportBlockList>(rb => rb.MontEventId == id);
            Assert.IsTrue(reportBlockLists.All(r=>r.MontEventId==id));

            // _spClient.Query<Infrastructure.Sharepoint.SpEntities.ReportBlockList>(rbl => rbl.MontEventId == id);
            //List<SpVendorBlock> spVendorBlocks = _sharepointClient.GetAll<SpVendorBlock>();
        }
 [TestMethod]
        public void DocQueryTest()
 {
     var vendorDocses = spclient.GetAll<VendorDocs>();
     VendorDocs docs = vendorDocses.FirstOrDefault(v => v.Id == 1338);
     var Linq2Caml = spclient.Query<VendorDocs>(v => v.Id == 1338).FirstOrDefault();
     VendorDocs byId = spclient.GetById<VendorDocs>(1338);
            Assert.AreEqual(byId,docs);
     Assert.AreEqual(byId, Linq2Caml);
        }

           [TestMethod]
    public void NewsContentQueryTest()
        {
            var vendorDocses = spclient.GetAll<NewsContent>();
                var id = 3953;
                NewsContent docs = vendorDocses.FirstOrDefault(v => v.Id == id);
            var Linq2Caml = spclient.Query<NewsContent>(v => v.Id == id).FirstOrDefault();
                NewsContent byId = spclient.GetById<NewsContent>(id);

            var byIdStr = JsonConvert.SerializeObject(byId);
            Assert.AreEqual(byIdStr, JsonConvert.SerializeObject(docs));
            Assert.AreEqual(byIdStr, JsonConvert.SerializeObject(Linq2Caml));

         
        }
    }
 

}