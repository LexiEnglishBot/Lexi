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

    def get_answer(self, prompt: str,system_message:str,response_format:str,model:str) -> str:
        """
        Send a prompt to the Groq API and get a response.

        :param prompt: The prompt to send to the API.
        :user_message:the message marked as user message to provide more context at first
        :system_message:the message marked as system message for better response 
        :response_format:default is text . can be json_object,
        :model: distil-whisper-large-v3-en,gemma2-9b-it,gemma-7b-it,llama3-groq-70b-8192-tool-use-preview,llama3-groq-8b-8192-tool-use-preview,llama-3.1-70b-versatile,llama-3.1-8b-instant,llama-guard-3-8b,llama3-70b-8192,llama3-8b-8192,mixtral-8x7b-32768,whisper-large-v3
        :return: The response from the API as a string.
        """
        headers = {
            'Authorization': f'Bearer {self.api_key}',  # Adjust according to API key type
            'Content-Type': 'application/json'
        }
     
        payload = {            
            'messages':[
              {'role':'system','content':system_message},
              {'role':'user','content':prompt}                
            ],            
            'model':model,
            'response_format':{"type":response_format}          
        }

        try:
            response = requests.post(f'{self.api_url}', json=payload, headers=headers)
            response.raise_for_status()  # Raise an HTTPError for bad responses
            response_data = response.json()
            y = response_data.get('choices', 'No answer found')[0]['message']['content']                               
            return y
        except requests.exceptions.RequestException as e:
            # Handle errors such as network issues, invalid responses, etc.
            print(f"An error occurred: {e}")
            return 'Error occurred while fetching the answer.'