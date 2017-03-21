#region License

/*
Licensed to Blue Chilli Technology Pty Ltd and the contributors under the MIT License (the "License").
You may not use this file except in compliance with the License.
See the LICENSE file in the project root for more information.
*/

#endregion

using System;
using Xunit;

using ChilliSource.Core;
using System.Threading.Tasks;

namespace Core
{
    
    public class ServiceResultTests
    {
        class Dummy
        {

        }

        [Fact]
        public void AsSuccess_ShouldSetFieldsCorrectly()
        {
            var result = ServiceResult.AsSuccess("test message");
            Assert.True(result.IsSuccessful);
            Assert.False(result.IsCancelled);
            Assert.Null(result.Exception);
            Assert.Equal("test message", result.Message);

            var genericResult = ServiceResult<Dummy>.AsSuccess(new Dummy());
            Assert.True(genericResult.IsSuccessful);
            Assert.False(genericResult.IsCancelled);
            Assert.Null(genericResult.Exception);
            Assert.Null(genericResult.Message);
            Assert.Equal(typeof(Dummy), genericResult.Result.GetType());
        }

        [Fact]
        public void AsCancel_ShouldSetFieldsCorrectly()
        {
            var result = ServiceResult.AsCancel();
            Assert.False(result.IsSuccessful);
            Assert.True(result.IsCancelled);
            Assert.Null(result.Exception);
            Assert.Null(result.Message);

            var genericResult = ServiceResult<Dummy>.AsCancel();
            Assert.False(genericResult.IsSuccessful);
            Assert.True(genericResult.IsCancelled);
            Assert.Null(genericResult.Exception);
            Assert.Null(genericResult.Message);
            Assert.Null(genericResult.Result);
        }

        [Fact]
        public void AsFailure_ShouldSetFieldsCorrectly_WhenGivenException()
        {
            var result = ServiceResult.AsFailure(new Exception("test exception"), 404);
            Assert.False(result.IsSuccessful);
            Assert.False(result.IsCancelled);
            Assert.Equal("test exception", result.Message);
            Assert.Equal("test exception", result.Exception.Message);
            Assert.Equal(404, result.StatusCode);

            var genericResult = ServiceResult<Dummy>.AsFailure(new Exception("test exception"), new Dummy(), 404);
            Assert.False(genericResult.IsSuccessful);
            Assert.False(genericResult.IsCancelled);
            Assert.Equal("test exception", genericResult.Message);
            Assert.Equal("test exception", genericResult.Exception.Message);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal(typeof(Dummy), genericResult.Result.GetType());
        }

        [Fact]
        public void AsFailure_ShouldSetFieldsCorrectly_WhenGivenMessage()
        {
            var result = ServiceResult.AsFailure("test exception", 404);
            Assert.False(result.IsSuccessful);
            Assert.False(result.IsCancelled);
            Assert.Equal("test exception", result.Message);
            Assert.Equal("test exception", result.Exception.Message);
            Assert.Equal(404, result.StatusCode);

            var genericResult = ServiceResult<Dummy>.AsFailure("test exception", new Dummy(), 404);
            Assert.False(genericResult.IsSuccessful);
            Assert.False(genericResult.IsCancelled);
            Assert.Equal("test exception", genericResult.Message);
            Assert.Equal("test exception", genericResult.Exception.Message);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal(typeof(Dummy), genericResult.Result.GetType());
        }

        [Fact]
        public void OnSuccess_ShouldBeCalled_WhenResultIsSuccessful()
        {
            var isAlwaysExecuted = false;
            var isSuccessExecuted = false;
            var isFailureExecuted = false;
            var result = ServiceResult<string>.AsSuccess("test")
                .OnSuccess((r) =>
                {
                    isSuccessExecuted = true;
                    return ServiceResult<string>.AsSuccess("ok");
                })
                .OnFailure(r =>
                {
                    isFailureExecuted = true;
                })
                .Always(r => isAlwaysExecuted = true);

            Assert.True(isSuccessExecuted);
            Assert.False(isFailureExecuted);
            Assert.True(isAlwaysExecuted);
			Assert.Equal("ok", result.Result);
            
        }

		[Fact]
		public void OnFailure_ShouldBeCalled_WhenResultIsNotSuccessful()
		{
			var isAlwaysExecuted = false;
			var isSuccessExecuted = false;
			var isFailureExecuted = false;
			var result = ServiceResult<string>.AsFailure("test")
				.OnSuccess((r) =>
				{
					isSuccessExecuted = true;
					return ServiceResult<string>.AsSuccess("ok");
				})
				.OnFailure(r =>
				{
					isFailureExecuted = true;
				})
				.Always(r => isAlwaysExecuted = true);

			Assert.False(isSuccessExecuted);
			Assert.True(isFailureExecuted);
			Assert.True(isAlwaysExecuted);
			Assert.Equal("test", result.Message);
			Assert.False(result.IsSuccessful);

		}

		[Fact]
		public void OnCancelled_ShouldCallOnCancelled_WhenResultIsCancelled()
		{
			var isAlwaysExecuted = false;
			var isSuccessExecuted = false;
			var isFailureExecuted = false;
			var isCancellExecuted = false;
			var result = ServiceResult<string>.AsCancel()
				.OnSuccess((r) =>
				{
					isSuccessExecuted = true;
					return ServiceResult<string>.AsSuccess("ok");
				})
				.OnFailure(r =>
				{
					isFailureExecuted = true;
				})
				.OnCancelled(r =>
				{
					isCancellExecuted = true;
				})
				.Always(r => isAlwaysExecuted = true);

			Assert.False(isSuccessExecuted);
			Assert.False(isFailureExecuted);
			Assert.True(isAlwaysExecuted);
			Assert.True(isCancellExecuted);
			Assert.True(result.IsCancelled);

		}

		[Fact]
		public void OnSuccess_ShouldCallOnFailure_WhenFirstOnSuccessReturnsFailureResult()
		{
			var isAlwaysExecuted = false;
			var isSuccessExecuted = false;
			var isFailureExecuted = false;
			var result = ServiceResult<string>.AsSuccess("ok")
				.OnSuccess((r) =>
				{
					isSuccessExecuted = true;
					return ServiceResult<string>.AsFailure("failed");
				})
				.OnFailure(r =>
				{
					isFailureExecuted = true;
				})
				.Always(r => isAlwaysExecuted = true);

			Assert.True(isSuccessExecuted);
			Assert.True(isFailureExecuted);
			Assert.True(isAlwaysExecuted);
			Assert.False(result.IsSuccessful);
			Assert.Equal("failed", result.Message);

		}

		[Fact]
		public async Task OnSuccessAsync_ShouldBeCalled_WhenReturnsSuccessResult()
		{
			var isAlwaysExecuted = false;
			var isSuccessExecuted = false;
			var isFailureExecuted = false;
			var result = await Task.FromResult(ServiceResult<string>.AsSuccess("ok"))
				.OnSuccessAsync((r) =>
				{
					isSuccessExecuted = true;
					return Task.FromResult(ServiceResult<string>.AsSuccess("ok"));
				})
				.OnFailureAsync(r =>
				{
					isFailureExecuted = true;
					return Task.Delay(0);
				})
			    .AlwaysAsync(r =>
				{
					isAlwaysExecuted = true;
					return Task.Delay(0);
				});

			Assert.True(isSuccessExecuted);
			Assert.False(isFailureExecuted);
			Assert.True(isAlwaysExecuted);
			Assert.True(result.IsSuccessful);
			Assert.Equal("ok", result.Result);

		}

		[Fact]
		public void Combine_ShouldFail_WhenResultConsistsAtLeastOneErrorResult()
		{
			var res1 = ServiceResult.AsFailure("failed");
			var res2 = ServiceResult.AsSuccess();
			var res3 = ServiceResult.AsFailure("test");

			var r = ServiceResult.Combine(res1, res2, res3);

			Assert.False(r.IsSuccessful);
			Assert.True(r.Message.Contains("failed"));
		}

		[Fact]
		public void Combine_ShouldSucceed_WhenResultConsistsAllSuccess()
		{
			var res1 = ServiceResult.AsSuccess();
			var res2 = ServiceResult.AsSuccess();
			var res3 = ServiceResult.AsSuccess();

			var r = ServiceResult.Combine(res1, res2, res3);

			Assert.True(r.IsSuccessful);
			Assert.False(r.Message.Contains("failed"));
		}
    }
}
