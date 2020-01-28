using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SharpUpDate
{
    public interface ImplementSharpUpdate
    {
        ///<summary>
        /// The name of your application as you want it displayed on the update form
        /// </summary>
        string ApplicationName { get; }
        ///<summary>
        /// An identified string to use to identify you application in the update.xml
        /// Should be the same as you appID in the update.xml
        /// </summary>
        string ApplicationID { get; }
        ///<summary>
        /// The current assmebly
        /// </summary>
        Assembly ApplicationAssembly { get; }
        ///<summary>
        /// The version of you current application
        /// </summary>
        Version ApplicationVersion { get; }
        ///<summary>
        /// The version of you current application
        /// </summary>
        Icon ApplicationIcon { get; }
        ///<summary>
        /// The version of you current application
        /// </summary>
        Uri UpdateXmlLocation { get; }
        ///<summary>
        /// The version of you current application
        /// </summary>\
        Form Context { get; }
    }
