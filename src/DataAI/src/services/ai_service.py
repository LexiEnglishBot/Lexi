import requests

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
        payload = {
            'prompt': prompt
        }

        try:
            response = requests.post(f'{self.api_url}/query', json=payload, headers=headers)
            response.raise_for_status()  # Raise an HTTPError for bad responses
            response_data = response.json()
            return response_data.get('answer', 'No answer found')
        except requests.exceptions.RequestException as e:
            # Handle errors such as network issues, invalid responses, etc.
            print(f"An error occurred: {e}")
            return 'Error occurred while fetching the answer.'