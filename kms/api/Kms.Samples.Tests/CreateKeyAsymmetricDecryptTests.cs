/*
 * Copyright 2020 Google LLC
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

using Google.Cloud.Kms.V1;
using Xunit;

[Collection(nameof(KmsFixture))]
public class CreateKeyAsymmetricDecryptTest
{
    private readonly KmsFixture _fixture;
    private readonly CreateKeyAsymmetricDecryptSample _sample;

    public CreateKeyAsymmetricDecryptTest(KmsFixture fixture)
    {
        _fixture = fixture;
        _sample = new CreateKeyAsymmetricDecryptSample();
    }

    [Fact]
    public void CreatesKey()
    {
        // Run the sample code.
        var result = _sample.CreateKeyAsymmetricDecrypt(
            projectId: _fixture.ProjectId, locationId: _fixture.LocationId, keyRingId: _fixture.KeyRingId,
            id: _fixture.RandomId());

        // Get the key.
        var key = _fixture.KmsClient.GetCryptoKey(result.CryptoKeyName);

        Assert.Equal(CryptoKey.Types.CryptoKeyPurpose.AsymmetricDecrypt, key.Purpose);
        Assert.Equal(CryptoKeyVersion.Types.CryptoKeyVersionAlgorithm.RsaDecryptOaep2048Sha256, key.VersionTemplate.Algorithm);
    }
}
