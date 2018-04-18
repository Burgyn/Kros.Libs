﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Kros.KORM.Query
{
    /// <summary>
    /// An IDbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.
    /// DbSet is a concrete implementation of IDbSet.
    /// </summary>
    /// <typeparam name="T">The type that defines the set.</typeparam>
    public interface IDbSet<T> : IEnumerable<T>
    {
        /// <summary>
        /// Adds the item to the context underlying the set in the Added state such that it will be inserted
        /// into the database when CommitChanges is called.
        /// </summary>
        /// <param name="entity">The item to add.</param>
        void Add(T entity);

        /// <summary>
        /// Adds the items to the context underlying the set in the Added state such that it will be inserted
        /// into the database when CommitChanges is called.
        /// </summary>
        /// <param name="entities">The items to add.</param>
        void Add(IEnumerable<T> entities);

        /// <summary>
        /// Marks the item as Edited such that it will be updated in the database when CommitChanges is called.
        /// </summary>
        /// <param name="entity">The item to edit.</param>
        void Edit(T entity);

        /// <summary>
        /// Marks the items as Edited such that it will be updated in the database when CommitChanges is called.
        /// </summary>
        /// <param name="entities">The items to edit.</param>
        void Edit(IEnumerable<T> entities);

        /// <summary>
        /// Marks the item as Deleted such that it will be deleted from the database when CommitChanges is called.
        /// </summary>
        /// <param name="entity">The item to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Marks the items as Deleted such that it will be deleted from the database when CommitChanges is called.
        /// </summary>
        /// <param name="entities">The items to delete.</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Rolls back all pending changes.
        /// </summary>
        void Clear();

        /// <summary>
        /// Commits all pending changes to the database.
        /// </summary>
        void CommitChanges();

        /// <summary>
        /// List of items in Added state.
        /// </summary>
        IEnumerable<T> AddedItems { get; }

        /// <summary>
        /// List of items in Edited state.
        /// </summary>
        IEnumerable<T> EditedItems { get; }

        /// <summary>
        /// List of items in Deleted state.
        /// </summary>
        IEnumerable<T> DeletedItems { get; }

        /// <summary>
        /// Executes bulk insert over pending added items.
        /// </summary>
        /// <example>
        ///   <code source="..\Examples\Kros.KORM.Examples\WelcomeExample.cs" title="Bulk insert" region="BulkInsert" lang="C#" />
        /// </example>
        void BulkInsert();

        /// <summary>
        /// Executes bulk insert over <paramref name="items"/>.
        /// </summary>
        /// <param name="items">The items to insert.</param>
        void BulkInsert(IEnumerable<T> items);

        /// <summary>
        /// Executes bulk update over pending edited items.
        /// </summary>
        /// <example>
        ///   <code source="..\Examples\Kros.KORM.Examples\WelcomeExample.cs" title="Bulk update" region="BulkUpdate" lang="C#" />
        /// </example>
        void BulkUpdate();

        /// <summary>
        /// Executes bulk update over <paramref name="items"/>.
        /// </summary>
        /// <param name="items">The items to update.</param>
        void BulkUpdate(IEnumerable<T> items);

        /// <summary>
        /// Executes bulk update over pending edited items with specific action.
        /// </summary>
        /// <param name="tempTableAction">The action execute on temp table (modify data in temp table).
        /// <list type="bullet">
        /// <item>
        /// <c>IDbConnection</c> - the temp table connection.
        /// </item>
        /// <item>
        /// <c>IDbTransaction</c> - the temp table transaction.
        /// </item>
        /// <item>
        /// <c>string</c> - the temp table name.
        /// </item>
        /// </list></param>
        void BulkUpdate(Action<IDbConnection, IDbTransaction, string> tempTableAction);

        /// <summary>
        /// Executes bulk update over <paramref name="items"/> with specific action.
        /// </summary>
        /// <param name="items">The items to update.</param>
        /// <param name="tempTableAction">The action execute on temp table (modify data in temp table).
        /// <list type="bullet">
        /// <item>
        /// <c>IDbConnection</c> - the temp table connection.
        /// </item>
        /// <item>
        /// <c>IDbTransaction</c> - the temp table transaction.
        /// </item>
        /// <item>
        /// <c>string</c> - the temp table name.
        /// </item>
        /// </list></param>
        void BulkUpdate(IEnumerable<T> items, Action<IDbConnection, IDbTransaction, string> tempTableAction);

    }
}