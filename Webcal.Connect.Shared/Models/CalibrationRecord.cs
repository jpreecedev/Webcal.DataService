﻿namespace Connect.Shared.Models
{
    using System;

    public class CalibrationRecord : BaseNotification
    {
        private DateTime? _calibrationTime;

        public DateTime? CalibrationTime
        {
            get { return _calibrationTime; }
            set
            {
                _calibrationTime = value;

                if (value.GetValueOrDefault().Year == 1970)
                {
                    _calibrationTime = null;
                }
            }
        }

        public double MaxSpeed { get; set; }
        public DateTime? NextCalibrationDate { get; set; }
        public string OdometerValue { get; set; }
        public string Purpose { get; set; }
        public string SensorSerialNumber { get; set; }
        public string TyreSize { get; set; }
        public string TyreCircumference { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string VehicleRegistrationNation { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string VuPartNumber { get; set; }
        public string VuSerialNumber { get; set; }
        public string WFactor { get; set; }
        public string KFactor { get; set; }
        public string TachographManufacturer { get; set; }
        public bool IsSelected { get; set; }
        public string CardSerialNumber { get; set; }
    }
}