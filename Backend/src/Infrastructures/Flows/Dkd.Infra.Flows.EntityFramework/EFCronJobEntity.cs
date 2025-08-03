// ==========================================================================
//  Dkd.Infra.Flows Headless CMS
// ==========================================================================
//  Copyright (c) Dkd.Infra.Flows UG (haftungsbeschraenkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

namespace Dkd.Infra.Flows.EntityFramework;

public sealed class EFCronJobEntity
{
    public string Id { get; set; }

    public DateTimeOffset DueTime { get; set; }

    public string Data { get; set; }
}
