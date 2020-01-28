using System;

namespace SharpUpdate
{
    ///<summary>
    ///Contains update information
    /// </summary>
    internal class LatestUpdate
    {
        private Version version;
        ///<summary>
        ///The update version #
        /// </summary>
        internal Version Version
        {
            get { return this.version; }
        }

        private Uri url;
        ///<summary>
        ///The location of the update binary
        /// </summary>
        internal Uri Uri
        {
            get { return this.url; }
        }

        private string filename;
        ///<summary>
        ///The file name of the binary
        ///for use on local computer
        /// </summary>

        internal string Filename
        {
            get {return this.filename; }
        }

        private string description;
        ///<summary>
        ///The location of the update binary
        /// </summary>
        internal string Description
        {
            get{return this.description; }
        }

        private string md5;
        ///<summary>
        ///The MDS of the update's binary
        /// </summary>
        internal string MD5
        {
            get { return this.md5; }
        }
    }
}
