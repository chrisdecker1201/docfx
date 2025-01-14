﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Common;

public class FilePathComparerWithEnvironmentVariable
    : IEqualityComparer<string>
{
    private readonly FilePathComparer _inner;

    public static readonly FilePathComparerWithEnvironmentVariable OSPlatformSensitiveComparer = new(new FilePathComparer());
    public static readonly FilePathComparerWithEnvironmentVariable OSPlatformSensitiveRelativePathComparer = new(new FilePathComparer(true));

    public FilePathComparerWithEnvironmentVariable(FilePathComparer inner)
    {
        _inner = inner;
    }

    public bool Equals(string x, string y)
    {
        return _inner.Equals(Environment.ExpandEnvironmentVariables(x), Environment.ExpandEnvironmentVariables(y));
    }

    public int GetHashCode(string obj)
    {
        return _inner.GetHashCode(Environment.ExpandEnvironmentVariables(obj));
    }
}
