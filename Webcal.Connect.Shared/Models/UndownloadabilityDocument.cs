namespace Webcal.Connect.Shared.Models
{
    using System;

    [Serializable]
    public class UndownloadabilityDocument : Document
    {
        public override bool IsNew
        {
            get { return false; }
        }
    }
}