// Copyright © 2012-2021 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Symbio;
using Vlingo.Symbio.Store.Object;

namespace Vgoairlines.Inventory.Model
{
    public sealed class AircraftState : StateObject
    {
        public AircraftState(string id,
            Registration registration,
            ManufacturerSpecification manufacturerSpecification,
            Carrier carrier)
        {
            Id = id;
            Registration = registration;
            ManufacturerSpecification = manufacturerSpecification;
            Carrier = carrier;
        }

        public string Id { get; }
        public Registration Registration { get; }
        public ManufacturerSpecification ManufacturerSpecification { get; }
        public Carrier Carrier { get; }

        public static AircraftState IdentifiedBy(string id) => 
            new AircraftState(id, null, null, null);

        public AircraftState Consign(Registration registration,
            ManufacturerSpecification manufacturerSpecification,
            Carrier carrier) =>
            new AircraftState(Id, registration, manufacturerSpecification, carrier);
    }
}