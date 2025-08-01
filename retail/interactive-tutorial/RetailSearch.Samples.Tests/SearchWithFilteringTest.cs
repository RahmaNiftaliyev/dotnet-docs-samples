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
    public class SearchWithFilteringTest
    {
        [Fact(Skip = "https://github.com/GoogleCloudPlatform/dotnet-docs-samples/issues/3151")]
        public void TestSearchWithFiltering()
        {
            const string ExpectedProductTitleName = "Tee";
            const string ExpectedProductColor = "Black";

            var firstPage = SearchWithFilteringTutorial.Search().First();

            Assert.Contains(firstPage, result => result.Product.Title.Contains(ExpectedProductTitleName) && result.Product.Title.Contains(ExpectedProductColor));
            Assert.Contains(firstPage, result => result.Product.ColorInfo.ColorFamilies.Contains(ExpectedProductColor));
        }
    }
}
