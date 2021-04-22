// Copyright © 2012-2021 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Actors;
using Vlingo.Xoom.Common;

namespace Vgoairlines.Inventory.Model
{
    public interface IAircraft
    {
        ICompletes<AircraftState> Consign(Registration registration, ManufacturerSpecification manufacturerSpecification, Carrier carrier);
    }
    
    public static class AircraftExtensions
    {
        public static ICompletes<AircraftState> Consign(Stage stage, Registration registration, ManufacturerSpecification manufacturerSpecification, Carrier carrier)
        {
            var address = stage.AddressFactory.UniquePrefixedWith("g-");
            var aircraftActor = stage.ActorFor<IAircraft>(() => new AircraftEntity(address.IdString));
            return aircraftActor.Consign(registration, manufacturerSpecification, carrier);
        }
    }
}