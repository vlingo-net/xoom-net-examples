// Copyright © 2012-2023 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System;
using Vlingo.Xoom.Common.Version;
using Vlingo.Xoom.Lattice.Model;

namespace Vgoairlines.Inventory.Model
{
    public class AircraftConsigned : IdentifiedDomainEvent
    {
        private Guid _eventId;

        public AircraftConsigned(AircraftState state) : base(SemanticVersion.From("1.0.0").ToValue())
        {
            AircraftId = state.Id;
            Model = state.ManufacturerSpecification.Model;
            SerialNumber = state.ManufacturerSpecification.SerialNumber;
            TailNumber = state.Registration.TailNumber;
            _eventId = Guid.NewGuid(); //TODO: Define the event id
        }

        public string AircraftId { get; }
        public string Model { get; }
        public string SerialNumber { get; }
        public string TailNumber { get; }

        public override string Identity => _eventId.ToString();
    }
}