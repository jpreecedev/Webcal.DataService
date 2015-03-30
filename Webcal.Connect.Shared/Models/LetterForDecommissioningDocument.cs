namespace Connect.Shared.Models
{
    using System;

    [Serializable]
    public class LetterForDecommissioningDocument : Document
    {
        public override bool IsNew
        {
            get { return false; }
        }
    }
}