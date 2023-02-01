// Copyright © 2012-2023 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

namespace Vgoairlines.Inventory.Model
{
    public class ManufacturerSpecification
    {
        private ManufacturerSpecification(string manufacturer, string model, string serialNumber)
        {
            Manufacturer = manufacturer;
            Model = model;
            SerialNumber = serialNumber;
        }

        public string Manufacturer { get; }
        public string Model { get; }
        public string SerialNumber { get; }

        public static ManufacturerSpecification Of(string manufacturer, string model, string serialNumber) => 
            new ManufacturerSpecification(manufacturer, model, serialNumber);
    }
}