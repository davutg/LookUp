Array.prototype.where = function (filter) {

    var collection = this;

    switch (typeof filter) {

        case 'function':
            return $.grep(collection, filter);

        case 'object':
            for (var property in filter) {
                if (!filter.hasOwnProperty(prop))
                    continue; // ignore inherited properties

                collection = $.grep(collection, function (item) {
                    return item[property] === filter[property];
                });
            }
            return collection.slice(0); // copy the array 
            // (in case of empty object filter)

        default:
            throw new TypeError('func must be either a' +
                'function or an object of properties and values to filter by');
    }
};


Array.prototype.firstOrDefault = function (func) {
    return this.where(func)[0] || null;
};


/*
    http://stackoverflow.com/a/18936797/413032
    Usage:

    var persons = [{ name: 'foo', age: 1 }, { name: 'bar', age: 2 }];

    // returns an array with one element:
    var result1 = persons.where({ age: 1, name: 'foo' });

    // returns the first matching item in the array, or null if no match
    var result2 = persons.firstOrDefault({ age: 1, name: 'foo' }); 
*/