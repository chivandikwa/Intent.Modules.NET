﻿using EfCoreTestSuite.CosmosDb.IntentGenerated.Core;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations;

namespace EfCoreTestSuite.CosmosDb.IntegrationTests;

[Collection(CollectionFixture.CollectionDefinitionName)]
public class GeneralEFTests
{
    private readonly DataContainerFixture _fixture;

    public GeneralEFTests(DataContainerFixture fixture)
    {
        _fixture = fixture;
    }

    private ApplicationDbContext DbContext => _fixture.DbContext;

    [IgnoreOnCiBuildFact]
    public void Test_A_Unidirectional_1_To_0to1_Association()
    {
        var src = new A_RequiredComposite() { RequiredCompositeAttr = "test 1", PartitionKey = "ABC" };
        DbContext.A_RequiredComposites.Add(src);
        DbContext.SaveChanges();

        var dst = new A_OptionalDependent() { OptionalDependentAttr = "test 2" };
        src.A_OptionalDependent = dst;
        DbContext.SaveChanges();

        var owner = DbContext.A_RequiredComposites.SingleOrDefault(p => p.Id == src.Id);
        Assert.NotNull(owner);
        Assert.NotNull(owner.A_OptionalDependent);
    }

    [IgnoreOnCiBuildFact]
    public void Test_B_Unidirectional_0to1_To_0to1_Association()
    {
        var src = new B_OptionalAggregate() { OptionalAggregateAttr = "test 1", PartitionKey = "ABC" };
        DbContext.B_OptionalAggregates.Add(src);
        DbContext.SaveChanges();

        var dst = new B_OptionalDependent() { OptionalDependentAttr = "test 2", PartitionKey = "ABC" };
        DbContext.B_OptionalDependents.Add(dst);
        DbContext.SaveChanges();

        src.B_OptionalDependent = dst;
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.B_OptionalAggregates.SingleOrDefault(p => p.Id == src.Id));
        Assert.NotNull(DbContext.B_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id));
        Assert.Equal(dst, DbContext.B_OptionalAggregates.SingleOrDefault(p => p.Id == src.Id)?.B_OptionalDependent);

        src.B_OptionalDependent = null;
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.B_OptionalAggregates.SingleOrDefault(p => p.Id == src.Id));
        Assert.NotNull(DbContext.B_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id));
        Assert.Null(DbContext.B_OptionalAggregates.SingleOrDefault(p => p.B_OptionalDependentId == dst.Id));
    }

    [IgnoreOnCiBuildFact]
    public void Test_C_Unidirectional_1_To_Many_Association()
    {
        var src = new C_RequiredComposite() { RequiredCompositeAttr = "test 1", PartitionKey = "ABC" };
        DbContext.C_RequiredComposites.Add(src);
        DbContext.SaveChanges();

        var dstList = new List<C_MultipleDependent>
        {
            new C_MultipleDependent() { MultipleDependentAttr = "test 2" },
            new C_MultipleDependent() { MultipleDependentAttr = "test 3" }
        };

        src.C_MultipleDependents.AddRange(dstList);
        DbContext.SaveChanges();

        var owner = DbContext.C_RequiredComposites.SingleOrDefault(p => p.Id == src.Id);
        Assert.NotNull(owner);
        Assert.Equal(dstList.Count, owner.C_MultipleDependents.Count(p => dstList.Contains(p)));

        // I previously had an orphan check here. Keeping just in case.
        // Assert.Throws<DbUpdateException>(() =>
        // {
        //     var orphan = new C_MultipleDependent();
        //     DbContext.Set<C_MultipleDependent>().Add(orphan);
        //     
        //     DbContext.SaveChanges();
        // });
    }

    [IgnoreOnCiBuildFact]
    public void Test_D_Unidirectional_0to1_To_Many_Association()
    {
        var src = new D_OptionalAggregate() { OptionalAggregateAttr = "test 1", PartitionKey = "ABC" };
        DbContext.D_OptionalAggregates.Add(src);
        DbContext.SaveChanges();

        var dstList = new List<D_MultipleDependent>
        {
            new D_MultipleDependent() { MultipleDependentAttr = "test 2", PartitionKey = "ABC" },
            new D_MultipleDependent() { MultipleDependentAttr = "test 3", PartitionKey = "ABC" }
        };

        src.D_MultipleDependents.AddRange(dstList);
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.D_OptionalAggregates.SingleOrDefault(p => p.Id == src.Id));
        Assert.Equal(dstList.Count, DbContext.D_MultipleDependents.Count(p => dstList.Contains(p)));

        dstList.ForEach(x => x.D_OptionalAggregateId = null);
        DbContext.SaveChanges();

        Assert.Equal(dstList.Count, DbContext.D_MultipleDependents.Count(p => dstList.Contains(p)));
    }

    [IgnoreOnCiBuildFact]
    public void Test_E_Bidirectional_1_To_1_Association()
    {
        var src = new E_RequiredCompositeNav() { RequiredCompositeNavAttr = "test 1", PartitionKey = "ABC" };
        DbContext.E_RequiredCompositeNavs.Add(src);

        var dst = new E_RequiredDependent() { RequiredDependentAttr = "test 2" };
        src.E_RequiredDependent = dst;

        DbContext.SaveChanges();

        var owner = DbContext.E_RequiredCompositeNavs.SingleOrDefault(p => p.Id == src.Id);
        Assert.NotNull(owner);
        Assert.NotNull(owner.E_RequiredDependent);

        // These constraints are not being enforced
        
        // Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() =>
        // {
        //     DbContext.E_RequiredCompositeNavs.Add(new E_RequiredCompositeNav() { RequiredCompositeNavAttr = "test 3", PartitionKey = "ABC" });
        //     DbContext.SaveChanges();
        // });
        //
        // Assert.Throws<InvalidOperationException>(() =>
        // {
        //     DbContext.Set<E_RequiredDependent>().Add(new E_RequiredDependent());
        //     DbContext.SaveChanges();
        // });
    }

    [IgnoreOnCiBuildFact]
    public void Test_F_Bidirectional_0to1_To_0to1_Association()
    {
        var src = new F_OptionalAggregateNav() { OptionalAggrNavAttr = "test 1", PartitionKey = "ABC" };
        DbContext.F_OptionalAggregateNavs.Add(src);
        DbContext.SaveChanges();

        var dst = new F_OptionalDependent() { OptionalDependentAttr = "test 2", PartitionKey = "ABC" };
        DbContext.F_OptionalDependents.Add(dst);
        DbContext.SaveChanges();

        src.F_OptionalDependent = dst;
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.F_OptionalAggregateNavs.SingleOrDefault(p => p.Id == src.Id));
        Assert.NotNull(DbContext.F_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id));
        Assert.Equal(dst, DbContext.F_OptionalAggregateNavs.SingleOrDefault(p => p.Id == src.Id)?.F_OptionalDependent);
        Assert.Equal(src, DbContext.F_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id)?.F_OptionalAggregateNav);

        src.F_OptionalDependent = null;
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.F_OptionalAggregateNavs.SingleOrDefault(p => p.Id == src.Id));
        Assert.NotNull(DbContext.F_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id));
        Assert.Null(DbContext.F_OptionalAggregateNavs.SingleOrDefault(p => p.Id == src.Id)?.F_OptionalDependent);
        Assert.Null(DbContext.F_OptionalDependents.SingleOrDefault(p => p.Id == dst.Id)?.F_OptionalAggregateNav);
    }

    [IgnoreOnCiBuildFact]
    public void Test_G_Bidirectional_1_To_Many_Association()
    {
        var src = new G_RequiredCompositeNav() { RequiredCompNavAttr = "test 1", PartitionKey = "ABC" };
        DbContext.G_RequiredCompositeNavs.Add(src);
        DbContext.SaveChanges();

        var dstList = new List<G_MultipleDependent>
        {
            new G_MultipleDependent() { MultipleDepAttr = "test 2" },
            new G_MultipleDependent() { MultipleDepAttr = "test 3" }
        };

        src.G_MultipleDependents.AddRange(dstList);
        DbContext.SaveChanges();

        var owner = DbContext.G_RequiredCompositeNavs.SingleOrDefault(p => p.Id == src.Id);
        Assert.NotNull(owner);
        Assert.Equal(dstList.Count, owner.G_MultipleDependents.Count(p => dstList.Contains(p)));

        // I previously had an orphan check here. Keeping just in case.
        // Assert.Throws<DbUpdateException>(() =>
        // {
        //     var orphan = new G_MultipleDependent();
        //     DbContext.Set<G_MultipleDependent>().Add(orphan);
        //     DbContext.SaveChanges();
        // });
    }

    [IgnoreOnCiBuildFact]
    public void Test_H_Bidirectional_0to1_To_Many_Association()
    {
        var src = new H_OptionalAggregateNav() { OptionalAggrNavAttr = "test 1", PartitionKey = "ABC" };
        DbContext.H_OptionalAggregateNavs.Add(src);
        DbContext.SaveChanges();

        var dstList = new List<H_MultipleDependent>
        {
            new H_MultipleDependent() { MultipleDepAttr = "test 2", PartitionKey = "ABC" },
            new H_MultipleDependent() { MultipleDepAttr = "test 3", PartitionKey = "ABC" }
        };

        src.H_MultipleDependents.AddRange(dstList);
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.H_OptionalAggregateNavs.SingleOrDefault(p => p.Id == src.Id));
        Assert.Equal(dstList.Count, DbContext.H_MultipleDependents.Count(p => dstList.Contains(p)));

        dstList.ForEach(x => x.H_OptionalAggregateNavId = null);
        DbContext.SaveChanges();

        Assert.Equal(dstList.Count, DbContext.H_MultipleDependents.Count(p => dstList.Contains(p)));
    }

    [IgnoreOnCiBuildFact]
    public void Test_J_Unidirectional_Many_To_1_Association()
    {
        var dst = new J_RequiredDependent() { RequiredDepAttr = "test 1", PartitionKey = "ABC" };
        DbContext.J_RequiredDependents.Add(dst);
        DbContext.SaveChanges();

        var srcList = new List<J_MultipleAggregate>
        {
            new J_MultipleAggregate() { MultipleAggrAttr = "test 2", PartitionKey = "ABC" },
            new J_MultipleAggregate() { MultipleAggrAttr = "test 3", PartitionKey = "ABC" }
        };
        srcList.ForEach(x =>
        {
            DbContext.J_MultipleAggregates.Add(x);
            x.J_RequiredDependent = dst;
        });
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.J_RequiredDependents.SingleOrDefault(p => p.Id == dst.Id));
        Assert.Equal(srcList.Count, DbContext.J_MultipleAggregates.Count(p => srcList.Contains(p)));

        // These constraints are not being enforced
        
        // Assert.Throws<DbUpdateException>(() =>
        // {
        //     var orphan = new J_MultipleAggregate() { PartitionKey = "ABC" };
        //     DbContext.J_MultipleAggregates.Add(orphan);
        //     DbContext.SaveChanges();
        // });
    }

    [IgnoreOnCiBuildFact]
    public void Test_K_Unidirectional_Many_To_0to1_Association()
    {
        var root = new K_SelfReference() { SelfRefAttr = "test 1", PartitionKey = "ABC" };
        DbContext.K_SelfReferences.Add(root);
        DbContext.SaveChanges();

        var children = new List<K_SelfReference>
        {
            new K_SelfReference() { SelfRefAttr = "test 2", PartitionKey = "ABC" },
            new K_SelfReference() { SelfRefAttr = "test 3", PartitionKey = "ABC" }
        };
        children.ForEach(x =>
        {
            DbContext.K_SelfReferences.Add(x);
            x.K_SelfReferenceAssociation = root;
        });
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.K_SelfReferences.SingleOrDefault(p => p.Id == root.Id));
        Assert.Equal(children.Count, DbContext.K_SelfReferences.Count(p => children.Contains(p)));
        Assert.Equal(children.Count, DbContext.K_SelfReferences.Count(p => p.K_SelfReferenceAssociationId == root.Id));
    }

    [IgnoreOnCiBuildFact]
    public void Test_M_Bidirectional_Many_To_0to1_Association()
    {
        var root = new M_SelfReferenceBiNav() { SelfRefBiNavAttr = "test 1", PartitionKey = "ABC" };
        DbContext.M_SelfReferenceBiNavs.Add(root);
        DbContext.SaveChanges();

        var children = new List<M_SelfReferenceBiNav>
        {
            new M_SelfReferenceBiNav() { SelfRefBiNavAttr = "test 2", PartitionKey = "ABC" },
            new M_SelfReferenceBiNav() { SelfRefBiNavAttr = "test 3", PartitionKey = "ABC" }
        };
        children.ForEach(x =>
        {
            DbContext.M_SelfReferenceBiNavs.Add(x);
            x.M_SelfReferenceBiNavAssocation = root;
        });
        DbContext.SaveChanges();

        Assert.NotNull(DbContext.M_SelfReferenceBiNavs.SingleOrDefault(p => p.Id == root.Id));
        Assert.Equal(children.Count, DbContext.M_SelfReferenceBiNavs.Count(p => children.Contains(p)));
        Assert.Equal(children.Count, root.M_SelfReferenceBiNavs.Count);
    }

    [IgnoreOnCiBuildFact]
    public void Test_PartitionKey_Default()
    {
        var implicitKeyClass = new ImplicitKeyClass()
        {
            Attribute = "test1"
        };

        DbContext.ImplicitKeyClasses.Add(implicitKeyClass);

        var explicitKeyClass = new ExplicitKeyClass()
        {
            Attribute = "test2"
        };
        DbContext.ExplicitKeyClasses.Add(explicitKeyClass);

        DbContext.SaveChanges();

        var receivedImplicitKeyClass = DbContext.ImplicitKeyClasses.FirstOrDefault();
        Assert.NotNull(receivedImplicitKeyClass);
        Assert.NotEqual(Guid.Empty, receivedImplicitKeyClass.Id);
        Assert.Equal(implicitKeyClass.Attribute, receivedImplicitKeyClass.Attribute);

        var receivedExplicitKeyClass = DbContext.ExplicitKeyClasses.FirstOrDefault();
        Assert.NotNull(receivedExplicitKeyClass);
        Assert.NotEqual(Guid.Empty, receivedExplicitKeyClass.Id);
        Assert.Equal(explicitKeyClass.Attribute, receivedExplicitKeyClass.Attribute);
    }
}