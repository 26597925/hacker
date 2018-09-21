#include "safety.h"
#include <stdio.h>

char debug_name[5][100]={"idaq.exe","idaq64.exe","VMwareTray.exe","SbieSvc.exe","OllyDBG.exe"};
char path_name[7][100]={"debug","virus","temp","ida","olly","disasm","hack"};


bool agree_control();  //�Ƿ�ͬ�ⱻ����
bool is_run();        //�Ƿ��Ѿ�����
bool is_debug();      //�Ƿ�����д���debug����
bool is_path_safe();  //�Ƿ�λ�ð�ȫ

bool find_debuger(const char *processname);   //�ȽϽ����б��Ƿ���ڵ���������
bool find_virus_path(const char *processname);  //λ���ַ����Ƚ�

int isSafety();

bool agree_control()
{
	if(IDNO == MessageBox(NULL,"Really want to be controlled?","!!!!!",MB_YESNO))
    {
        return true;  //ѯ�ʱ��������Ƿ�Ը��  
    }
	return false;
}

bool is_run()
{
	CreateMutexA(NULL,FALSE,"ZeroNet");
    if(GetLastError() == ERROR_ALREADY_EXISTS) {
        std::cout << "Same program already running" << std::endl;
        return true;   //��ѯ�Ƿ�������
    }
	return false;
}

bool find_debuger(const char *processname)
{
	for(int i=0;i<5;i++)
	{
		char *s=debug_name[i];
		while(*processname!='\0' && *processname==*s)
		{
			processname++;
			s++;
		}
		if(*processname=='\0' && *s=='\0'){
			return true;
		}
	}
	return false;
}


bool is_debug()
{
	//���ַ����Լ���   SEH+IsDebuggerPresent+.....+ȫ·�����+���̱���
	int IsSafe=0;
	PROCESSENTRY32 pe32;
	pe32.dwSize=sizeof(pe32);
	HANDLE hprocesssnapshot=CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS,0);
	if(INVALID_HANDLE_VALUE!=hprocesssnapshot)
	{
		BOOL bprocess=Process32First(hprocesssnapshot,&pe32);
		while(bprocess)
		{
			if(find_debuger(pe32.szExeFile))
			{
				IsSafe++;
			}
		    bprocess=Process32Next(hprocesssnapshot,&pe32);
		}
	}
	if(IsSafe){
		return true;
	}
	else{
		return false;
	}
}

bool is_path_safe(){
	int IsSafe=0;
	char filename[MAX_PATH];
	if(GetModuleFileName(NULL,filename,MAX_PATH))
	{
		if(find_virus_path(filename))
		{
			IsSafe++;
		}
	}
	if(IsSafe)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool find_virus_path(const char *processname)
{
	const char *ori=processname;
	for(int i=0;i<7;i++)
	{
		processname=ori;
		while(*processname!='\0')
		{
			char *s=path_name[i];
			while(*processname!=*s && *processname!=(*s)-32 && *processname!='\0')
			{
				processname++;
			}
			while(*processname!='\0' && (*processname==*s || *processname==(*s)-32))
			{
				processname++;
				s++;
			}
			if(*s=='\0'){
				return true;
			}
		}
	}
	return false;
}



int isSafety()
{
	int IsSafe=0;

	if(agree_control()   //�ܾ�
		||is_run()
		||is_debug()
		||is_path_safe()
		/*||IsDebuggerPresent()*/
		)
	{  
        IsSafe++;  //ѯ�ʱ��������Ƿ�Ը��
    }
    return IsSafe;
}



