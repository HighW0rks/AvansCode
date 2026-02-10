from random import Random
rnd = Random()

def load_people() -> list[dict]:
    import json
    with open("people.json", "r") as f:
        names = json.load(f)
    return names["people"]

def randomize_list(list: list) -> list:
    rnd.shuffle(list)
    return list

def print_name(first_name, last_name):
    print(f"{first_name} {last_name}")

def print_name_reversed(first_name, last_name):
    first_name_rev = first_name[::-1]
    last_name_rev = last_name[::-1]
    print(f"{last_name_rev} {first_name_rev}")


def print_name_colored(first_name, last_name):
    print(f"\033[91m{first_name}\03 \033[94m{last_name}\033[0m")

print_styles = [print_name, print_name_reversed,print_name_colored]

def print_name_random_style(first_name, last_name):
    rnd.choice(print_styles)(first_name, last_name)