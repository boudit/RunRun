////  --------------------------------------------------------------------------------------------------------------------
////  <copyright file="BinarySerializerTests.cs" company="Eurofins">
////    Copyright (c) Eurofins. All rights reserved.
////  </copyright>
////  --------------------------------------------------------------------------------------------------------------------
//namespace Shared.Tests.Serializers
//{
//    using System;

//    using Shared.Serializers;

//    using Xunit;

//    public class BinarySerializerTests
//    {
//        private readonly BinarySerializer serializer;

//        public BinarySerializerTests()
//        {
//            this.serializer = new BinarySerializer();
//        }

//        [Fact]
//        public void ObjectToByteArray_WhenNullIsProvided_ThenReturnNull()
//        {
//            // Actors
            
//            // Activity
//            var result = this.serializer.ObjectToByteArray(null);

//            // Asserts
//            Assert.Null(result);
//        }

//        [Fact]
//        public void ObjectToByteArray_WhenObjectIsProvided_ThenReturnObjectSerialized()
//        {
//            // Actors
//            var obj = new TestObject()
//                          {
//                              Id = Guid.NewGuid(),
//                              Property1 = "Test",
//                              Property2 = true,
//                              Property3 = new TestObject2 { Id = Guid.NewGuid() }
//                          };

//            // Activity
//            var result = this.serializer.ObjectToByteArray(obj);

//            // Asserts
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public void ByteArrayTo_WhenBytesAreProvided_ThenReturnObject()
//        {
//            // Actors
//            var obj = new TestObject()
//            {
//                Id = Guid.NewGuid(),
//                Property1 = "Test",
//                Property2 = true,
//                Property3 = new TestObject2 { Id = Guid.NewGuid() }
//            };

//            // Activity
//            var serialization = this.serializer.ObjectToByteArray(obj);
//            var result = this.serializer.ByteArrayTo<TestObject>(serialization);

//            // Asserts
//            Assert.NotSame(obj, result);
//            Assert.Equal(obj.Id, result.Id);
//            Assert.Equal(obj.Property1, result.Property1);
//            Assert.Equal(obj.Property2, result.Property2);
//            Assert.NotSame(obj.Property3, result.Property3);
//            Assert.Equal(obj.Property3.Id, result.Property3.Id);
//        }

//        [Fact]
//        public void ByteArrayToObject_WhenBytesAreProvided_ThenReturnObject()
//        {
//            // Actors
//            var obj = new TestObject()
//            {
//                Id = Guid.NewGuid(),
//                Property1 = "Test",
//                Property2 = true,
//                Property3 = new TestObject2 { Id = Guid.NewGuid() }
//            };

//            // Activity
//            var serialization = this.serializer.ObjectToByteArray(obj);
//            var result = this.serializer.ByteArrayToObject(serialization);

//            // Asserts
//            Assert.NotSame(obj, result);
//            //Assert.Equal(obj.Id, result.Id);
//            //Assert.Equal(obj.Property1, result.Property1);
//            //Assert.Equal(obj.Property2, result.Property2);
//            //Assert.NotSame(obj.Property3, result.Property3);
//            //Assert.Equal(obj.Property3.Id, result.Property3.Id);
//        }

//        [Serializable]
//        public class TestObject
//        {
//            public Guid Id { get; set; }

//            public string Property1 { get; set; }

//            public bool Property2 { get; set; }

//            public TestObject2 Property3 { get; set; }
//        }

//        [Serializable]
//        public class TestObject2
//        {
//            public Guid Id { get; set; }
//        }
//    }
//}