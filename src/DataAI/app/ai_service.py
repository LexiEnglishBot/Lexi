import requests
import json
class GroqService:
    def __init__(self, api_url: str, api_key: str):
        """
        Initialize the GroqService with the API URL and API key.
        
        :param api_url: The base URL of the Groq API endpoint.
        :param api_key: The API key for authentication (if required).
        """
        self.api_url = api_url
        self.api_key = api_key

    def get_answer(self, prompt: str) -> str:
        """
        Send a prompt to the Groq API and get a response.

        :param prompt: The prompt to send to the API.
        :return: The response from the API as a string.
        """
        headers = {
            'Authorization': f'Bearer {self.api_key}',  # Adjust according to API key type
            'Content-Type': 'application/json'
        }
        system_prompt='''
           
    You are required to generate a JSON output that adheres to the following specifications:

    1. **Input**: An English text.
    2. **Output**: A JSON object with a list of up to 7 advanced or complex idioms or grammatical structures found in the input text.
    3. **Format**:
       - Each item in the list should be an object with the following properties:
         - `"text"`: The idiom or grammatical structure, presented generically.
         - `"meaning"`: The meaning of the idiom or grammatical structure.
         - `"sentence"`: A sentence from the input text containing the idiom or grammatical structure. The sentence should be no longer than 30 words.
    4. **Instructions**:
       - Your answer text must be parsable to json
       - Do not provide any additional explanations or descriptions.
       - The JSON should contain a maximum of 7 entries.
       - Ensure that `"text"` is formatted generically and independently of its usage in the sentence.
        '''
        
        payload = {
            
            'messages':[
              {'role':'system','content':system_prompt},
              {'role':'user','content':prompt}                
            ],            
            'model':'llama3-8b-8192'
        }

        try:
            response = requests.post(f'{self.api_url}', json=payload, headers=headers)
            response.raise_for_status()  # Raise an HTTPError for bad responses
            response_data = response.json()
            y = response_data.get('choices', 'No answer found')[0]['message']['content']
            print(y)            
            x=json.loads(y)
            return x
        except requests.exceptions.RequestException as e:
            # Handle errors such as network issues, invalid responses, etc.
            print(f"An error occurred: {e}")
            return 'Error occurred while fetching the answer.'