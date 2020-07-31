# General Python Best Practices

## Dictionaries
- use `dict_name.get("key")` instead of `key in` to avoid looping. By default returns `None` if not found, 2nd arg is to specify return value if not found