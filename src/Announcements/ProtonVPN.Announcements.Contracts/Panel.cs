﻿/*
 * Copyright (c) 2022 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;

namespace ProtonVPN.Announcements.Contracts
{
    public class Panel
    {
        public string Incentive { get; set; }
        public string IncentivePrice { get; set; }
        public string IncentiveSuffix { get; set; }
        public string Pill { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public IList<PanelFeature> Features { get; set; }
        public string FeaturesFooter { get; set; }
        public PanelButton Button { get; set; }
        public string PageFooter { get; set; }
        public FullScreenImage FullScreenImage { get; set; }
    }
}