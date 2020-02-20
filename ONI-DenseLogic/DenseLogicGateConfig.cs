﻿/*
 * Copyright 2020 Dense Logic Team
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 * and associated documentation files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
 * BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System.Collections.Generic;
using UnityEngine;

namespace ONI_DenseLogic
{
    public class DenseLogicGateConfig : IBuildingConfig
    {
        public const string ID = "DenseGate";

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 2, 3,
                "dense_MULTI_kanim", 30, 4.0f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2,
                TUNING.MATERIALS.REFINED_METALS, 800.0f, BuildLocationRule.LogicBridge,
                TUNING.BUILDINGS.DECOR.PENALTY.TIER1, TUNING.NOISE_POLLUTION.NOISY.TIER1);
            buildingDef.Overheatable = false;
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.ViewMode = OverlayModes.Logic.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.SceneLayer = Grid.SceneLayer.Building;
            buildingDef.AlwaysOperational = true;
            buildingDef.LogicInputPorts = new List<LogicPorts.Port>()
            {
                LogicPorts.Port.RibbonInputPort(
                    DenseLogicGate.INPUTID1,
                    new CellOffset(0, -1),
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.LOGIC_PORT,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.INPUT_PORT_ACTIVE,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.INPUT_PORT_INACTIVE,
                    true
                ),
                LogicPorts.Port.RibbonInputPort(
                    DenseLogicGate.INPUTID2,
                    new CellOffset(0, 1),
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.LOGIC_PORT,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.INPUT_PORT_ACTIVE,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.INPUT_PORT_INACTIVE,
                    true
                )
            };
            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>()
            {
                LogicPorts.Port.RibbonOutputPort(
                    DenseLogicGate.OUTPUTID,
                    new CellOffset(1, 0),
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.LOGIC_PORT_OUTPUT,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.OUTPUT_PORT_ACTIVE,
                    STRINGS.BUILDINGS.PREFABS.LOGICRIBBONREADER.OUTPUT_PORT_INACTIVE,
                    true
                )
            };
            GeneratedBuildings.RegisterWithOverlay(OverlayModes.Logic.HighlightItemIDs, ID);
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<DenseLogicGate>();
        }
    }
}
