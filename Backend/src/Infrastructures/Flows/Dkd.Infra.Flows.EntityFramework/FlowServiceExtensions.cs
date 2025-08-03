// ==========================================================================
//  Dkd.Infra.Flows Headless CMS
// ==========================================================================
//  Copyright (c) Dkd.Infra.Flows UG (haftungsbeschraenkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Dkd.Infra.Flows;
using Microsoft.EntityFrameworkCore;
using Dkd.Infra.Flows.CronJobs.Internal;
using Dkd.Infra.Flows.EntityFramework;
using Dkd.Infra.Flows.Internal.Execution;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class FlowServiceExtensions
{
    public static CronJobsBuilder AddEntityFrameworkStore<TDbContext, TContext>(this CronJobsBuilder builder)
        where TDbContext : DbContext
    {
        builder.Services.TryAddSingleton<ICronJobStore<TContext>, EFCronJobStore<TDbContext, TContext>>();

        return builder;
    }

    public static FlowsBuilder AddEntityFrameworkStore<TDbContext, TContext>(this FlowsBuilder builder)
        where TContext : FlowContext
        where TDbContext : DbContext
    {
        builder.Services.TryAddSingleton<IFlowStateStore<TContext>, EFFlowStateStore<TDbContext, TContext>>();

        builder.Services.TryAddSingleton<IDbFlowsBulkInserter,
            NullDbFlowsBulkInserter>();

        return builder;
    }
}
