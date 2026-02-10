from utils import print_name_random_style,load_people,randomize_list


if __name__ == "__main__":
    people = load_people()
    # random order of the people list
    people = randomize_list(people)
    
    for person in people:
        print_name_random_style(person["first_name"], person["last_name"])