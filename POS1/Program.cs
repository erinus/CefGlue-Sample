using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlus.POS
{
    /*
    using MongoDB.Bson;
    using MongoDB.Driver;
    */
    static class Program
    {
        /*
        public static Dictionary<string, IMongoCollection<BsonDocument>> Collections = new Dictionary<string, IMongoCollection<BsonDocument>>();
        */
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*
            MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(ConfigurationManager.AppSettings["MongoDBConnectionString"]));
            mongoClientSettings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            IMongoClient mongoClient = new MongoClient(mongoClientSettings);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("log");

            Program.Collections.Add("ui", mongoDatabase.GetCollection<BsonDocument>("ui"));
            */
            /*
            Program.Collections["ui"].DeleteMany(new BsonDocument { });
            */
            /*
            Random random = new Random();
            DateTime start = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                BsonDocument bsonDocument = new BsonDocument
                {
                    { "eventName", "click" },
                    { "eventData", new BsonDocument { { "x", random.Next(0, 1024) }, { "y", random.Next(0, 768) } } }
                };
                Program.Collections["ui"].InsertOne(bsonDocument);
            }
            MessageBox.Show(string.Format("{0} seconds", (DateTime.Now - start).Seconds));
            */

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((object sender, UnhandledExceptionEventArgs e) =>
            {
                Exception ex = e.ExceptionObject as Exception;

                File.AppendAllText(
                    @"crashes\non-ui-errors.txt",
                    string.Format("IsTerminating: {0}", e.IsTerminating) + Environment.NewLine +
                    string.Format("Result: {0}", ex.HResult) + Environment.NewLine +
                    string.Format("Exception: {0}", ex.InnerException) + Environment.NewLine +
                    string.Format("Message: {0}", ex.Message) + Environment.NewLine +
                    string.Format("Source: {0}", ex.Source) + Environment.NewLine +
                    string.Format("TargetSite: {0}", ex.TargetSite) + Environment.NewLine +
                    string.Format("HelpLink: {0}", ex.HelpLink) + Environment.NewLine +
                    string.Format("StackTrace: {0}", ex.StackTrace)
                );
            });
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler((object sender, ThreadExceptionEventArgs e) =>
            {
                Exception ex = e.Exception;

                File.AppendAllText(
                    @"crashes\ui-errors.txt",
                    string.Format("Result: {0}", ex.HResult) + Environment.NewLine +
                    string.Format("Exception: {0}", ex.InnerException) + Environment.NewLine +
                    string.Format("Message: {0}", ex.Message) + Environment.NewLine +
                    string.Format("Source: {0}", ex.Source) + Environment.NewLine +
                    string.Format("TargetSite: {0}", ex.TargetSite) + Environment.NewLine +
                    string.Format("HelpLink: {0}", ex.HelpLink) + Environment.NewLine +
                    string.Format("StackTrace: {0}", ex.StackTrace)
                );
            });
            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(args));
        }
    }
}
