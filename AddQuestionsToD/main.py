import requests
import json
import sqlite3

url  = "https://opentdb.com/api.php?amount=10&category=15"

def main():

    response = requests.get(url)  # send request
    data = json.loads(response.text)
    results = data["results"]

    conn = sqlite3.connect("TriviaDB.sqlite")
    cursor = conn.cursor()

    for result in results:
        question = result["question"]
        correct_answer = result["correct_answer"]
        wrong_answers = result["incorrect_answers"]
        wrong_answer1, wrong_answer2, wrong_answer3 = wrong_answers

        # Insert the question into the table
        cursor.execute("""
            INSERT INTO QUESTIONS (QUESTION, CORRECT_ANSWER, WRONG_ANSWER1, WRONG_ANSWER2, WRONG_ANSWER3)
            VALUES (?, ?, ?, ?, ?)
        """, (question, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3))

    # Commit the changes and close the connection
    conn.commit()
    conn.close()

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
