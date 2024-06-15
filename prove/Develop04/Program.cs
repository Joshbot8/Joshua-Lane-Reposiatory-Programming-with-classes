import time
import random
import itertools

class MindfulnessActivity:
    def __init__(self, duration):
        self._duration = duration

    def start(self):
        print(f"Starting {self.__class__.__name__} Activity")
        print(self.description())
        self.set_duration()
        self.prepare_to_begin()
        self.perform_activity()
        self.end()

    def description(self):
        raise NotImplementedError

    def set_duration(self):
        self._duration = int(input("Enter the duration of the activity in seconds: "))

    def prepare_to_begin(self):
        print("Prepare to begin...")
        self.show_animation(5)

    def perform_activity(self):
        raise NotImplementedError

    def end(self):
        print("Good job! You have completed the activity.")
        print(f"You completed the {self.__class__.__name__} Activity for {self._duration} seconds.")
        self.show_animation(5)

    def show_animation(self, duration):
        for _ in range(duration):
            for char in "|/-\\":
                print(char, end="\r", flush=True)
                time.sleep(0.25)


class BreathingActivity(MindfulnessActivity):
    def description(self):
        return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."

    def perform_activity(self):
        start_time = time.time()
        while time.time() - start_time < self._duration:
            print("Breathe in...")
            self.show_countdown(3)
            print("Breathe out...")
            self.show_countdown(3)

    def show_countdown(self, count):
        for i in range(count, 0, -1):
            print(i)
            time.sleep(1)


class ReflectionActivity(MindfulnessActivity):
    _prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]

    _questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ]

    def description(self):
        return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."

    def perform_activity(self):
        start_time = time.time()
        prompt = random.choice(self._prompts)
        print(prompt)
        while time.time() - start_time < self._duration:
            question = random.choice(self._questions)
            print(question)
            self.show_animation(5)


class ListingActivity(MindfulnessActivity):
    _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ]

    def description(self):
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."

    def perform_activity(self):
        prompt = random.choice(self._prompts)
        print(prompt)
        self.show_animation(5)
        start_time = time.time()
        items = []
        while time.time() - start_time < self._duration:
            item = input("List an item: ")
            items.append(item)
        print(f"You listed {len(items)} items.")


def main():
    activities = {
        '1': BreathingActivity,
        '2': ReflectionActivity,
        '3': ListingActivity
    }

    while True:
        print("Menu:")
        print("1. Breathing Activity")
        print("2. Reflection Activity")
        print("3. Listing Activity")
        print("4. Quit")

        choice = input("Choose an activity: ")
        if choice == '4':
            break
        elif choice in activities:
            duration = int(input("Enter the duration for the activity in seconds: "))
            activity = activities[choice](duration)
            activity.start()
        else:
            print("Invalid choice, please try again.")

if __name__ == "__main__":
    main()
