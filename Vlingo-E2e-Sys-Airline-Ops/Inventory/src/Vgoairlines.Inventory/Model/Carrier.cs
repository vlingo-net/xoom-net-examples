// Copyright © 2012-2021 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

namespace Vgoairlines.Inventory.Model
{
    public class Carrier
    {
        private Carrier(string name, CarrierType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public CarrierType Type { get; }

        public static Carrier Of(string name, CarrierType type) => new Carrier(name, type);
    }
}