// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Xenomorph;

/// <summary>
/// Handles the acid spit gun action
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class NeurotoxinGlandComponent : Component
{
    [DataField, AutoNetworkedField]
    public bool Active = false;

    [DataField]
    public EntProtoId ActionId = "ActionAcidSpit";

    [DataField]
    public EntityUid? Action;
}
