#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System.Collections;
using System.Collections.Generic;
using ChilliSource.Core;
using Xunit;


namespace Core
{
	
	//public class ObservableRangeCollectionTests
	//{

	//	[Fact]
	//	public void AddRange_ShouldAddItemsAndNotify()
	//	{
	//		var collection = new ObservableRangeCollection<string>();
	//		var propertyTracker = new PropertyChangedTracker(collection);
	//		var collectionTracker = new CollectionChangedTracker(collection);

	//		collection.AddRange(new List<string> { "item1", "item2" });

	//		Assert.Equal(2, collection.Count);
	//		Assert.Equal(2, propertyTracker.ChangedProperties.Count);
	//		Assert.Equal("Count", propertyTracker.ChangedProperties[0]);
	//		Assert.Equal("Item[]", propertyTracker.ChangedProperties[1]);
	//		Assert.Equal(1, collectionTracker.Actions.Count);
	//		Assert.Equal("Add", collectionTracker.Actions[0]);
	//	}


	//	[Fact]
	//	public void RemoveRange_ShouldRemoveItemsAndNotify()
	//	{
	//		var collection = new ObservableRangeCollection<string>();
	//		collection.AddRange(new List<string> { "item1", "item2" });
	//		var collectionTracker = new CollectionChangedTracker(collection);
	//		collection.RemoveRange(new List<string> { "item1" });

	//		Assert.Equal(1, collection.Count);
	//		Assert.Equal(1, collectionTracker.Actions.Count);
	//		Assert.Equal("Reset", collectionTracker.Actions[0]);
	//	}

	//	[Fact]
	//	public void ReplaceRange_ShouldReplaceItemsAndNotify()
	//	{
	//		var collection = new ObservableRangeCollection<string>();
	//		collection.AddRange(new List<string> { "item1", "item2" });

	//		var propertyTracker = new PropertyChangedTracker(collection);
	//		var collectionTracker = new CollectionChangedTracker(collection);

	//		collection.ReplaceRange(new List<string> { "item3" });

	//		Assert.Equal(1, collection.Count);
	//		Assert.Equal("item3", collection[0]);
	//		Assert.Equal(2, propertyTracker.ChangedProperties.Count);
	//		Assert.Equal("Count", propertyTracker.ChangedProperties[0]);
	//		Assert.Equal("Item[]", propertyTracker.ChangedProperties[1]);
	//		Assert.Equal(1, collectionTracker.Actions.Count);
	//		Assert.Equal("Reset", collectionTracker.Actions[0]);
	//	}

	//	[Fact]
	//	public void InsertRange_ShouldInsertItemsAndNotify()
	//	{
	//		var collection = new ObservableRangeCollection<string>();
	//		collection.AddRange(new List<string> { "item1", "item2" });

	//		var propertyTracker = new PropertyChangedTracker(collection);
	//		var collectionTracker = new CollectionChangedTracker(collection);

	//		collection.InsertRange(1, new List<string> { "item3" });

	//		Assert.Equal(3, collection.Count);
	//		Assert.Equal("item3", collection[1]);
	//		Assert.Equal(2, propertyTracker.ChangedProperties.Count);
	//		Assert.Equal("Count", propertyTracker.ChangedProperties[0]);
	//		Assert.Equal("Item[]", propertyTracker.ChangedProperties[1]);
	//		Assert.Equal(1, collectionTracker.Actions.Count);
	//		Assert.Equal("Add", collectionTracker.Actions[0]);
	//	}

	//	[Fact]
	//	public void ObservableCollection_ShouldImplementIList()
	//	{
	//		var collection = new ObservableRangeCollection<string>();
 //           Assert.True(collection is IList);
	//	}
	//}
}
