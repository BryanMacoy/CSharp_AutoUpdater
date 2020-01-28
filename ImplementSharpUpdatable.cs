using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace SupportSharpUpdate
{
    /// <summary>
    ///  Provides application update support in C#
    /// </summary>
    public class SharpUpdater
    {
        ///<summary>
        ///The LatestUpdate object that holds the encapsulated Update XML data
        /// </summary>
        private LatestUpdate update;

        /// <summary>
        /// Holds the program-to-update's info
        /// </summary>
        private ImplementSharpUpdatable programInfo;

        /// <summary>
        /// The dialog to accept an update
        /// </summary>
        private AcceptupdateForm acceptUpdateForm;

        /// <summary>
        /// Thread to find update
        /// </summary>
        private BackgroundWorker bgWorker;

        /// <summary>
        /// Creates a new SharpUpdater Object
        /// </summary>
        /// <Param name="applicationName">The name of the application so it can be displayed on dialog boxes to user</Param>
        /// <param name="appId">A unique Id for the application, same as in update xlm</param>
        /// <param name="updateXmlLocation">The Url for the program's update.xml</param>
        public SharpUpdater(ImplementSharpUpdatable programInfo)
        {
            this.programInfo = programInfo;

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        ///<summary>
        ///Checks for an update for the program passed.
        ///If there is an update, a dialog asking to downlaod will appear
        /// </summary>
        public void DoUpdate()
        {
            bgWorker.RunWorkerAsync(Tuple.Create<ImplementSharpUpdatable, LatestUpdate>(this.programInfo, this.update));
        }

        ///<summary>
        ///Checks for/parses update.xml on server
        /// </summary>
        /// <param name="e">Tuple&lt;ImplementSharpUpdatable, LatestUpdate&gt;</param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImplementSharpUpdatable program = (ImplementSharpUpdatable)((Tuple<ImplementSharpUpdatable, LatestUpdate>)e.Argument).Item1;
            latestUpdate update = (latestUpdate)((Tuple<ImplementSharpUpdatable, LatestUpdate>)e.Argument).Item2;

            /// Check for update on server
            if (!UpdateXmlExist(program))
            {
                e.Cancel = true;
                return;
            }

            //Parse update xml
            e.Result = ParseUpdateXml(program);
        }

        /// <summary>
        /// After the background worker is done, prompt to update if there is one
        /// </summary>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            this.update = (LatestUpdate)e.Result;

            if (this.update == null)
                return;

            if (this.update.IsNewerThan(this.programInfo.ApplicationAssembly.GetName().Version))
            {
                // Add dialog here to check if you want to download
                this.acceptUpdateForm = new AcceptupdateForm(this.programInfo, this.update);
            }
        }
    }
}
