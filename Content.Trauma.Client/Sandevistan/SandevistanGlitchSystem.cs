// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Sandevistan;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Player;

namespace Content.Trauma.Client.Sandevistan;

public sealed class SandevistanGlitchSystem : EntitySystem
{
    private SandevistanGlitchOverlay _overlay = default!;

    [Dependency] private readonly IPlayerManager _playerManager = default!;
    [Dependency] private readonly IOverlayManager _overlayManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SandevistanGlitchComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<SandevistanGlitchComponent, ComponentShutdown>(OnShutdown);

        SubscribeLocalEvent<SandevistanGlitchComponent, LocalPlayerAttachedEvent>(OnPlayerAttached);
        SubscribeLocalEvent<SandevistanGlitchComponent, LocalPlayerDetachedEvent>(OnPlayerDetached);

        _overlay = new();
    }

    private void OnPlayerAttached(Entity<SandevistanGlitchComponent> ent, ref LocalPlayerAttachedEvent args) =>
        _overlayManager.AddOverlay(_overlay);

    private void OnPlayerDetached(Entity<SandevistanGlitchComponent> ent, ref LocalPlayerDetachedEvent args) =>
        _overlayManager.RemoveOverlay(_overlay);

    private void OnInit(Entity<SandevistanGlitchComponent> ent, ref ComponentInit args)
    {
        if (_playerManager.LocalEntity != ent.Owner)
            return;

        _overlayManager.AddOverlay(_overlay);
    }

    private void OnShutdown(Entity<SandevistanGlitchComponent> ent, ref ComponentShutdown args)
    {
        if (_playerManager.LocalEntity != ent.Owner)
            return;

        _overlayManager.RemoveOverlay(_overlay);
    }
}
