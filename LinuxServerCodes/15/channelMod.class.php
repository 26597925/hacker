<?php
class channelMod extends mngMod {
	private $rdConfig;
	
    public function __construct() {
        parent::__construct();
		$this->rdConfig = new cpRedis(array(
			"group" => "config"
		));
    }
	
	public function index() {
		$fid = in($_GET[0]);
        $act = $_GET['action'];
        if ($act == "del") {
            $conorder = array();
            $conorder['id'] = intval($fid);;
            $this->model->table('channel')->where($conorder)->delete();
			$conorder = array();
			$conorder['clid'] = intval($fid);;
			$this->model->table('cschannel')->where($conorder)->delete();
            echo 1;
        } else {
			if(!empty($_GET['cat_id'])){
				$con[] = 'B.id='.$_GET['cat_id'];
			}
            if($_GET['search']){
				if(!empty($_GET['keyword'])){
					$keyword = '&'.$_SERVER['QUERY_STRING'];
					$con[] ='C.name LIKE \'%' . $_GET['keyword'] . '%\'';
					$this->assign('keyword', $_GET['keyword']);
				}
            }
			$con[] = "1=1";
			$condition = implode(" and ", $con);
			$this->assign('cat_id', $_GET['cat_id']);
            //分页开始
            $url = __URL__ . '/index-{page}.html?cat_id='.$_GET['cat_id'].$keyword;
            $listRows = 18; //每页显示的信息条数 
            $page = new Page();
            $cur_page = $page->getCurPage($url);
            $limit_start = ($cur_page - 1) * $listRows;
            $limit = $limit_start . ',' . $listRows;
            //获取总行数
			$class = $this->model->table('class')->select();
			 //读取数据开始
			$sql = "select C.*,B.name as cname,A.sort,A.etime from live_cschannel A join live_class B on A.csid = B.id 
			 join live_channel C on A.clid = C.id where $condition
			limit $limit";
            $info = $this->model->query($sql);
			$sql = "select count(*) as count from live_cschannel A join live_class B on A.csid = B.id 
			 join live_channel C on A.clid = C.id where $condition";
			$all = $this->model->query($sql);
			$allcount = $all[0]['count'];
			$this->assign('class', $class);
            $this->assign('allcount', $allcount);
            $this->assign('page', $page->show($url, $allcount, $listRows, 10, 5));
            $this->assign('info', $info);
            $this->display();
        }
	}
	
	public function edit(){
		$action = $_POST['action'];
        $close = in($_GET[close]);
        if ($action == 'post') {
            $id = $_POST['id'];
			unset($_POST['id']);
			$data = postinput($_POST);
            if ($id) {
                $condition['id'] = $id;
				$pinyin = new Pinyin();
				$py = $this->trimall($data['name']);
				$py = strtolower($pinyin->output($py));
				$channel = array(
					"number" => $data['number'],
					"name" => $data['name'],
					"epg" => $data['epg'],
					"channel" => $py
				);
                $result = $this->model->table('channel')->data($channel)->where($condition)->update();
				$condition = array();
				$condition['clid'] = $id;
				$cschannel = array(
					"csid" => $data['csid'],
					"sort" => $data['sort'],
					"atime" => time(),
					"etime" => time()
				);
				$this->model->table('cschannel')->data($cschannel)->where($condition)->update();
            } else {
				$condition['name'] = $tv["name"];
                $info = $this->model->table('channel')->where($condition)->find();
                if ($info) {
                    Error::show('相同名称的电台已存在！', 1);
                }else{
					$pinyin = new Pinyin();
					$py = $this->trimall($data['name']);
					$py = strtolower($pinyin->output($py));
					$channel = array(
						"number" => $data['number'],
						"name" => $data['name'],
						"epg" => $data['epg'],
						"channel" => $py
					);
					$clid = $this->model->table('channel')->data($channel)->insert();
					$cschannel = array(
						"csid" => $data['csid'],
						"clid" => $clid,
						"sort" => $data['sort'],
						"atime" => time(),
						"etime" => time()
					);
					$this->model->table('cschannel')->data($cschannel)->insert();
				}
            }
            Error::show('已成功提交！', 0, $this->closewindow());
        }else{
            $id = 0 + in($_GET[0]); //读取分类
            $close = in($_GET[close]);
			$class = $this->model->table('class')->select();
			if(!empty($id)){
				$sql = "select * from live_cschannel A
				 join live_channel B on A.clid = B.id where B.id=$id limit 1";
				$info = $this->model->query($sql);
				$this->assign('info', $info[0]);
            }
			$this->assign('class', $class);
            $this->assign('close', $close);
            $this->display();  
        }
	}
	
	public function createSource() {
		$type = array("默认", "电信", "移动", "联通");
		$time = time();
		foreach($type as $val){
			$str = $this->createClass($val);
			if($val == "默认"){
				$channel = "channel_$time.json";
				$key = "channel_url";
			}elseif($val == "电信"){
				$channel = "dxchannel_$time.json";
				$key = "dxchannel_url";
			}elseif($val == "移动"){
				$channel = "ydchannel_$time.json";
				$key = "ydchannel_url";
			}else{
				$channel = "ltchannel_$time.json";
				$key = "ltchannel_url";
			}
			$upload = "upload/".date("Ymd");
			if(!file_exists($upload)){
				mkdir($upload);
			}
			file_put_contents("$upload/$channel", $str);
			$this->rdConfig->set($key, "http://down.0755tv.net/$upload/$channel");
		}
		$this->rdConfig->set("channel_time", $time);
		/*header('Content-Type:text/json');
		header('Content-Disposition:attachment; filename="channel.json"');
		header('Content-Length:'.strlen($str));
		echo $str;*/
		echo "write success!";
	}
	
	private function createClass($type) {
		$channel = array();
		$class = $this->model->table('class')->order("sort asc")->select();
		if(!empty($class)) foreach($class as $info){
			$item['id'] = $info['id'];
			$item['name'] = $info['name'];
			$item['area'] = $info['area'];
			$item['list'] = $this->getChannel($info['id'], $type);
			$channel[] = $item;
		}
		return json_encode($channel);
	}
	
	public function editName() {
		 $condition['id'] = 0+$_POST['id'];
		 $data['name'] = in($_POST['name']);
		 $result = $this->model->table('channel')->data($data)->where($condition)->update();
		 echo $result;
	} 
	
	public function editNumber() {
		 $condition['id'] = 0+$_POST['id'];
		 $data['number'] = 0+$_POST['number'];
		 $result = $this->model->table('channel')->data($data)->where($condition)->update();
		 echo $result;
	} 
	
	
	public function editEpg() {
		 $condition['id'] = 0+$_POST['id'];
		 $data['epg'] = in($_POST['epg']);
		 $result = $this->model->table('channel')->data($data)->where($condition)->update();
		 echo $result;
	} 
	
	
	public function editSort() {
		 $condition['id'] = 0+$_POST['id'];
		 $data['sort'] = 0+$_POST['sort'];
		 $result = $this->model->table('cschannel')->data($data)->where($condition)->update();
		 echo $result;
	} 
	
	private function trimall($str)//删除空格
	{
		$qian=array(" ","　","\t","\n","\r");$hou=array("","","","","");
		return str_replace($qian,$hou,$str);    
	}
	
	private function getChannel($csid, $type) {
		$list = array();
		$sql = "select B.*,A.sort from live_cschannel A join live_channel B on A.clid = B.id 
			where A.csid=$csid order by A.sort asc";
		$channel = $this->model->query($sql);
		if(!empty($channel)) foreach($channel as $info){
			$item['number'] = $info['number'];
			$item['name'] = $info['name'];
			$item['epg'] = $info['epg'];
			$item['streams'] = $this->getSource($info['channel'], $type);
			$list[] = $item;
		}
		return $list;
	}
	
	private function getSource($channel, $type) {
		$list = array();
		$condition['channel'] = $channel;
		if($type == '默认'){
			$source = $this->model->table('source')->where($condition)->order("sort asc")->select();
		}else{
			$source = $this->model->table('source')->where($condition)->order("isp='$type' desc")->select();
		}
		if(!empty($source)) foreach($source as $info){
			$item['url'] = $info['url'];
			$item['mode'] = $info['mode'];
			$list[] = $item;
		}
		return $list;
	}
}
