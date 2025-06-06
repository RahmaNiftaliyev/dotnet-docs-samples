/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Cloud.ParameterManager.V1;

[Collection(nameof(ParameterManagerFixture))]
public class EnableParameterVersionTests
{
    private readonly ParameterManagerFixture _fixture;
    private readonly EnableParameterVersionSample _sample;

    public EnableParameterVersionTests(ParameterManagerFixture fixture)
    {
        _fixture = fixture;
        _sample = new EnableParameterVersionSample();
    }

    [Fact]
    public void EnableParameterVersion()
    {
        var (parameterId, versionId, parameter, payload) = _fixture.CreateParameterWithVersion();

        ParameterVersion parameterVersion = _fixture.CreateParameterVersion(parameterId, versionId, payload);
        ParameterVersion result = _sample.EnableParameterVersion(projectId: _fixture.ProjectId, parameterId: parameterId, versionId: versionId);

        Assert.NotNull(result);
        Assert.False(result.Disabled);
    }
}
