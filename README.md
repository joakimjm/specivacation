[![joakimjm MyGet Build Status](https://www.myget.org/BuildSource/Badge/joakimjm?identifier=f1e8fcb2-0cfa-4a8c-a4c2-75704bf3cda0)](https://www.myget.org/)

# Specification pattern

An implementation of the specification pattern that is basically copy pasted code from two solutions:

- [NSpecifications](https://github.com/jnicolau/NSpecifications)
- [SpecificationPattern](https://github.com/vkhorikov/SpecificationPattern)

# But why?
I feel the "new way" of NSpecifications a step in the wrong direction for maintainability because it's use of a [generic specification implementation](http://enterprisecraftsmanship.com/2016/02/08/specification-pattern-c-implementation/).

SpecificationPattern is only implemented through an abstract class, and I've had use cases where I like having the interface available to encapsulate the same business rule for multiple entity types. More importantly the way expressions are composed just don't work with MongoDB, which I use extensively. This is where [LINQKit](https://github.com/scottksmith95/LINQKit) comes into the picture. Now my only problem is which operations are supported by the Mongo driver :-x
