// ==========================================================================
//  Dkd.Infra.Flows Headless CMS
// ==========================================================================
//  Copyright (c) Dkd.Infra.Flows UG (haftungsbeschraenkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Microsoft.EntityFrameworkCore;

#pragma warning disable MA0048 // File name must match type name

namespace Dkd.Infra.Flows.EntityFramework;

public interface IDbFlowsBulkInserter
{
    Task BulkUpsertAsync<T>(DbContext dbContext, IEnumerable<T> entities,
        CancellationToken ct = default) where T : class;
}

public sealed class NullDbFlowsBulkInserter : IDbFlowsBulkInserter
{
    public Task BulkUpsertAsync<T>(DbContext dbContext, IEnumerable<T> entities,
        CancellationToken ct = default) where T : class
    {
        throw new NotSupportedException("Register a bulk inserter.");
    }
}
