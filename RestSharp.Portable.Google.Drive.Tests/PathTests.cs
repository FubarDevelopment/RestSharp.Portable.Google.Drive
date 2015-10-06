using Xunit;

namespace RestSharp.Portable.Google.Drive.Tests
{
    public class PathTests
    {
        [Fact]
        public void TestSplitEmpty()
        {
            var original = string.Empty;
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new string[0], result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitOne()
        {
            var original = "one";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { "one" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitOneTwo()
        {
            var original = "one/two";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { "one", "two" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitRootOne()
        {
            var original = "/one";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { string.Empty, "one" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitOneEscapeSlashTwo()
        {
            var original = @"one\/two";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { "one/two" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitOneEscapeBackslashTwo()
        {
            var original = @"one\\two";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { @"one\two" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestSplitOneEscapeSlashTwoThree()
        {
            var original = @"one\/two/three";
            var result = GoogleDriveService.SplitPath(original);
            Assert.Equal<string>(new[] { "one/two", "three" }, result);
            Assert.Equal(original, GoogleDriveService.CombinePath(null, result));
        }

        [Fact]
        public void TestCombine()
        {
            Assert.Equal("one", GoogleDriveService.CombinePath("one"));
            Assert.Equal("one/two", GoogleDriveService.CombinePath("one", "two"));
            Assert.Equal("one/two/three", GoogleDriveService.CombinePath("one", "two", "three"));
            Assert.Equal("one/", GoogleDriveService.CombinePath("one/"));
            Assert.Equal("one/two", GoogleDriveService.CombinePath("one/", "two"));
        }
    }
}
