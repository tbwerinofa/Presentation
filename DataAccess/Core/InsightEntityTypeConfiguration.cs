﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core;

public abstract class InsightEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    protected InsightEntityTypeConfiguration()
    {
        PostInitialize();
    }

    public abstract void Configure(EntityTypeBuilder<T> builder);

    /// <summary>
    /// Developers can override this method in custom partial classes
    /// in order to add some custom initialization code to constructors
    /// </summary>
    protected virtual void PostInitialize()
    {

    }
}