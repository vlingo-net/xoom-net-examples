// Copyright © 2012-2021 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Common;
using Vlingo.Lattice.Model.Stateful;

namespace Vgoairlines.Inventory.Model
{
    public class AircraftEntity : StatefulEntity<AircraftState>, IAircraft
    {
        private AircraftState _state;
        
        public AircraftEntity(string id) : base(id) => _state = AircraftState.IdentifiedBy(id);

        protected override void OnStateObject(AircraftState stateObject)
        {
            // TODO: check if not duplicated with State property
        }

        protected override void State(AircraftState state) => _state = state;

        public ICompletes<AircraftState> Consign(Registration registration, ManufacturerSpecification manufacturerSpecification, Carrier carrier)
        {
            var stateArg = _state.Consign(registration, manufacturerSpecification, carrier);
            return Apply(stateArg, new AircraftConsigned(stateArg), () => _state);
        }
    }
}