﻿// Copyright (c) 2025 ReactiveUI. All rights reserved.
// Licensed to ReactiveUI under one or more agreements.
// ReactiveUI licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.DependencyInjection;

namespace Splat.Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="MicrosoftDependencyResolver"/>.
/// </summary>
public static class SplatMicrosoftExtensions
{
    /// <summary>
    /// Initializes an instance of <see cref="MicrosoftDependencyResolver"/> that overrides the default <see cref="Locator"/>.
    /// </summary>
    /// <param name="serviceCollection">The <see cref="IServiceCollection"/>.</param>
    public static void UseMicrosoftDependencyResolver(this IServiceCollection serviceCollection) =>
#pragma warning disable CA2000
        // Will be disposed with the InternalLocator
        Locator.SetLocator(new MicrosoftDependencyResolver(serviceCollection));
#pragma warning restore CA2000

    /// <summary>
    /// Initializes an instance of <see cref="MicrosoftDependencyResolver"/> that overrides the default <see cref="Locator"/>
    /// with a built <see cref="IServiceProvider"/>.
    /// </summary>
    /// <remarks>
    /// If there is already a <see cref="MicrosoftDependencyResolver"/> serving as the
    /// <see cref="Locator.Current"/>, it'll instead update it to use the specified
    /// <paramref name="serviceProvider"/>.
    /// </remarks>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/>.</param>
    public static void UseMicrosoftDependencyResolver(this IServiceProvider serviceProvider)
    {
        if (Locator.Current is MicrosoftDependencyResolver resolver)
        {
            resolver.UpdateContainer(serviceProvider);
        }
        else
        {
#pragma warning disable CA2000
            // Will be disposed with the InternalLocator
            Locator.SetLocator(new MicrosoftDependencyResolver(serviceProvider));
#pragma warning restore CA2000
        }
    }
}
