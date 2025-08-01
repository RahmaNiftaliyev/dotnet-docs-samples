// Copyright 2021 Google Inc.

//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Linq;
using Xunit;

namespace RetailSearch.Samples.Tests
{
    public class SearchWithPaginationTest
    {
        [Fact(Skip = "https://github.com/GoogleCloudPlatform/dotnet-docs-samples/issues/3151")]
        public void TestSearchWithPagination()
        {
            const int pageSize = 6;
            const string ExpectedProductTitle = "Hoodie";

            var firstPage = SearchWithPaginationTutorial.Search().First();

            Assert.Contains(firstPage, result => result.Product.Title.Contains(ExpectedProductTitle));
            Assert.True(firstPage.Results.Count <= pageSize);
        }
    }
}
