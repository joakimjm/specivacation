[![Build Status](https://github.com/joakimjm/specivacation/actions/workflows/build.yml/badge.svg)](https://github.com/joakimjm/specivacation/actions/workflows/build.yml)

# SpeciVacation

Because the [specification](https://martinfowler.com/apsupp/spec.pdf) [pattern](https://en.wikipedia.org/wiki/Specification_pattern) is a pretty helpful tool in the struggle to keep code bases maintainable.

## Installation

Package is [available on NuGet](https://www.nuget.org/packages/SpeciVacation).

`dotnet add package SpeciVacation`

or

`Install-Package SpeciVacation`

## But why?

Composing specifications should be easy and just work no matter the database technology. This requires some work with the underlying C# `Expression`.

I am not a smart man, and working with `Expression`s feels to me like building a sandcastle with dry sand. There are many guides and good ideas on stackoverflow and elsewhere, that look like they should work, but then they don't. This is where [LINQKit](https://github.com/scottksmith95/LINQKit) comes into the picture and alleviates all the `Expression`-headaches. It's built for Entity Framework but also seems to _just work_ with the MongoDB drivers.

Granted, other implementations of the specification pattern already exist. However:

I feel the "new way" of [NSpecifications](https://github.com/jnicolau/NSpecifications) a step in the wrong direction for maintainability because it's use of a [generic specification implementation](http://enterprisecraftsmanship.com/2016/02/08/specification-pattern-c-implementation/).

[SpecificationPattern](https://github.com/vkhorikov/SpecificationPattern) (another open source piece of code) is only implemented through an abstract class, and I've had use cases where I like having the interface available to encapsulate the same business rule for multiple entity types. More importantly the way expressions are composed just don't work with MongoDB, which I use extensively. This is where [LINQKit](https://github.com/scottksmith95/LINQKit) comes into the picture. Now my only problem is which operations are supported by the Mongo driver :-x

## The name

The name NuGet package id `Specification` was already in use and I found it pretty punny because I was on vacation when I set up the repository and the MyGet CI.
